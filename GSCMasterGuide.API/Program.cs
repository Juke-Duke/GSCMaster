using System.Text.Json.Serialization;
using GSCMasterGuide.Domain.IRepositories;
using GSCMasterGuide.Infrastructure.Data;
using GSCMasterGuide.Infrastructure.Repositories;
using GSCMasterGuide.Infrastructure.Seed.Seeding;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddDbContext<GSCDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GSCDb")));

builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<IMoveRepository, MoveRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddMediatR(typeof(Program).Assembly);

var app = builder.Build();

app.UseHttpsRedirection();

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