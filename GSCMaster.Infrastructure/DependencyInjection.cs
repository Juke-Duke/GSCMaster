using GSCMaster.Application.IRepositories;
using GSCMaster.Infrastructure.Database;
using GSCMaster.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSCMaster.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<GSCMasterDBContext>();

        services.AddScoped<IPokemonRepository, PokemonRepository>();
        services.AddScoped<IMoveRepository, MoveRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();

        return services;
    }
}