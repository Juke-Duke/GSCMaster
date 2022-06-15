using GSCMasterGuide.Domain.IRepositories;
using GSCMasterGuide.Infrastructure.Data;
using GSCMasterGuide.Infrastructure.Repositories;
using GSCMasterGuide.Infrastructure.Seeding;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<GSCDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GSCDb")));

builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddMediatR(typeof(Program).Assembly);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GSCDbContext>();
    PokemonSeed.Seed(dbContext);
}

app.Run();