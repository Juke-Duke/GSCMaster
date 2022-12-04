using GSCMaster.Application.Repositories;
using GSCMaster.Application.Services;
using GSCMaster.Application.Services.Authentication;
using GSCMaster.Infrastructure.Services.Authenticaion;
using GSCMaster.Infrastructure.Database;
using GSCMaster.Infrastructure.Repositories;
using GSCMaster.Infrastructure.Services;
using GSCMaster.Infrastructure.Services.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;

namespace GSCMaster.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<GSCMasterDbContext>();

        services.AddAuthentication(config);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<ITrainerRepository, TrainerRepository>();
        services.AddScoped<IPokemonRepository, PokemonRepository>();
        services.AddScoped<IMoveRepository, MoveRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();

        return services;
    }

    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration config)
    {
        var JWTOptions = new JWTOptions();
        config.Bind(JWTOptions.SectionName, JWTOptions);

        services.AddSingleton(Options.Create(JWTOptions));
        services.AddSingleton<IJWTGenerator, JWTGenerator>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = JWTOptions.Issuer,
                    ValidAudience = JWTOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTOptions.SecretKey))
                };
            });

        return services;
    }
}