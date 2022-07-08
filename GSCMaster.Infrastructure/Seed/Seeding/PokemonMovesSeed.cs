using GSCMaster.Core.Entities;
using GSCMaster.Infrastructure.Database;

namespace GSCMaster.Infrastructure.Seed.Seeding;
public class PokemonMovesSeed
{
    public static void Seed(GSCDbContext context)
    {
        if (context.PokemonMoves.Any())
            return;

        context.SaveChanges();
    }
}