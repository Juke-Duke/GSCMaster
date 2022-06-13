using GSCMasterGuide.Infrastructure.Data;
using GSCMasterGuide.Domain.Entities;

namespace GSCMasterGuide.Infrastructure.Seeding
{
    public class PokemonSeed
    {
        public static void Seed(GSCDbContext context)
        {
            if (context.Pokemon.Any())
                return;

            var lines = File.ReadAllLines("Data\\SeedData\\PokemonSeedData.csv");
            lines = lines.Skip(1).ToArray();

            foreach (var line in lines)
            {
                var values = line.Split(',');

                context.Pokemon.Add(new Pokemon
                {
                    Name = values[1],
                    PrimaryType = (Type)Enum.Parse(typeof(Type), values[2]),
                    SecondaryType = values[3] == "None" ? Type.None : (Type)Enum.Parse(typeof(Type), values[3]),
                    Tier = (Tier)Enum.Parse(typeof(Tier), values[4]),
                    HP = int.Parse(values[5]),
                    Attack = int.Parse(values[6]),
                    Defense = int.Parse(values[7]),
                    SpAttack = int.Parse(values[8]),
                    SpDefense = int.Parse(values[9]),
                    Speed = int.Parse(values[10]),
                });
            }
            context.SaveChanges();
        }
    }
}