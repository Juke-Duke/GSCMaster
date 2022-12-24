using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using GSCMaster.Application.Services;
using GSCMaster.Application.Services.Authentication;
using GSCMaster.Application.Services.Repositories;
using GSCMaster.Infrastructure;
using GSCMaster.Infrastructure.Services;
using GSCMaster.Infrastructure.Services.Authenticaion;
using GSCMaster.Infrastructure.Services.Authentication;
using GSCMaster.Infrastructure.Services.Repositories;

namespace GSCMaster.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<GSCMasterDBConnection>();

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