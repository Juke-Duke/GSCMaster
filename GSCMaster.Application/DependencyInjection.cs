using System.Reflection;
using GSCMaster.Application.Common;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MapsterMapper;
using Mapster;
using FluentValidation;

namespace GSCMaster.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}