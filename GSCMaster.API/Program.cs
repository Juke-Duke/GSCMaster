using GSCMaster.Application;
using GSCMaster.Infrastructure;
using GSCMaster.Infrastructure.Seeding;
using HotChocolate.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddInfrastructure(builder.Configuration)
        .AddApplication();

    builder.Services
        .AddGraphQLServer()
        .AddAuthorization()
        .AddObjectIdConverters()
        .AddMongoDbProjections()
        .ConfigureSchema(sb => sb.ModifyOptions(opts => opts.StrictValidation = false))
        .InitializeOnStartup();

    builder.Services.AddCors();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.UseWebSockets();

    app.UseAuthentication();

    app.UseCors(builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());

    app.MapGraphQL().WithOptions(new GraphQLServerOptions
    {
        EnableGetRequests = true
    });

    var db = app.Services.GetRequiredService<GSCMasterDBConnection>();
    {
        // db.SeedItems();
        db.SeedTypes();
        db.SeedPokemon();
    }

    app.Run();
}