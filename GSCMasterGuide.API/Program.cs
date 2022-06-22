using System.Text;
using System.Text.Json.Serialization;
using GSCMasterGuide.Domain.Entities;
using GSCMasterGuide.Domain.IRepositories;
using GSCMasterGuide.Infrastructure.Data;
using GSCMasterGuide.Infrastructure.Repositories;
using GSCMasterGuide.Infrastructure.Seed.Seeding;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.Converters
                .Add(new JsonStringEnumConverter()));

builder.Services.AddDbContext<GSCDbContext>(options => options
                .UseSqlServer(builder.Configuration
                .GetConnectionString("GSCDb")));

builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>()
                .AddScoped<IPokemonRepository, PokemonRepository>()
                .AddScoped<IMoveRepository, MoveRepository>()
                .AddScoped<IItemRepository, ItemRepository>()
                .AddMediatR(typeof(Program).Assembly);

var identityBuilder = builder.Services.AddIdentityCore<Trainer>(opt =>
{
    // TODO make this secure
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;
    opt.SignIn.RequireConfirmedEmail = false;
    opt.Password.RequiredLength = 3;
    opt.Password.RequiredUniqueChars = 0;
})
    .AddEntityFrameworkStores<GSCDbContext>();

identityBuilder = new(identityBuilder.UserType, typeof(IdentityRole<uint>), identityBuilder.Services);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:SecretKey"]))
    };
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GSCDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Trainer>>();
    await UserSeed.Seed(userManager);
    PokemonSeed.Seed(dbContext);
    MoveSeed.Seed(dbContext);
    ItemSeed.Seed(dbContext);
}

app.Run();