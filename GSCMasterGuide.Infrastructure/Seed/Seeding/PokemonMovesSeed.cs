using GSCMasterGuide.Infrastructure.Data;
using GSCMasterGuide.Domain.Entities;

namespace GSCMasterGuide.Infrastructure.Seed.Seeding
{
    public class PokemonMovesSeed
    {
        public static void Seed(GSCDbContext context)
        {
            if (context.PokemonMoves.Any())
                return;

            context.SaveChanges();
        }
    }
}