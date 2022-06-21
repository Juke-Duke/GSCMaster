using System.Text;
using System.Text.Json.Serialization;
using GSCMasterGuide.Domain.IRepositories;
using GSCMasterGuide.Infrastructure.Data;
using GSCMasterGuide.Infrastructure.Repositories;
using GSCMasterGuide.Infrastructure.Seed.Seeding;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    PokemonSeed.Seed(dbContext);
    MoveSeed.Seed(dbContext);
    ItemSeed.Seed(dbContext);
}

app.Run();