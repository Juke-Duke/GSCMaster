using GSCMasterGuide.Infrastructure.Data;
using GSCMasterGuide.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<GSCDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GSCDb")));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GSCDbContext>();
    PokemonSeed.SeedTest(dbContext);
}

app.Run();