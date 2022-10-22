using GSCMaster.API.GraphQL.Queries;
using GSCMaster.Application;
using GSCMaster.Infrastructure;
using GSCMaster.Infrastructure.Database;
using GSCMaster.Infrastructure.Seeding;
using HotChocolate.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddInfrastructure(builder.Configuration)
        .AddApplication();

    builder.Services
        .AddGraphQLServer()
        .AddMongoDbProjections()
        .AddQueryType<PokemonQueries>();

    builder.Services.AddCors();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.UseWebSockets();

    app.UseCors(builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());

    app.MapGraphQL().WithOptions(new GraphQLServerOptions
    {
        EnableGetRequests = true
    });

    var db = app.Services.GetRequiredService<GSCMasterDBContext>();
    {
        Seeder.SeedPokemon(db);
    }

    app.Run();
}