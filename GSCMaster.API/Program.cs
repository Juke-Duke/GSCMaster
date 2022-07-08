using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using GSCMaster.Core.Entities;
using GSCMaster.Core.IRepositories;
using GSCMaster.Infrastructure.Database;
using GSCMaster.Infrastructure.Repositories;
using GSCMaster.Infrastructure.Seed.Seeding;
using MediatR;

namespace GSCMaster.API;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers()
                        .AddJsonOptions(x => x.JsonSerializerOptions.Converters
                        .Add(new JsonStringEnumConverter()));

        builder.Services.AddDbContext<GSCDbContext>(options => options
                        .UseSqlServer(builder.Configuration
                        .GetConnectionString("GSCDb")));

        builder.Services // .AddScoped<IAuthenticationRepository, AuthenticationRepository>()
                        .AddScoped<IPokemonRepository, PokemonRepository>()
                        .AddScoped<IMoveRepository, MoveRepository>()
                        .AddScoped<IItemRepository, ItemRepository>()
                        .AddMediatR(typeof(Program).Assembly);

        var identityBuilder = builder.Services.AddIdentityCore<Trainer>(options =>
        {
            // TODO make this secure
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 0;
        })
        .AddEntityFrameworkStores<GSCDbContext>();

        // identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(IdentityRole<uint>), identityBuilder.Services);

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
    }
}