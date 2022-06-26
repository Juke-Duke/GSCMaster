using GSCMasterGuide.Core.Entities;
using GSCMasterGuide.Infrastructure.Database;

namespace GSCMasterGuide.Infrastructure.Seed.Seeding;
public class PokemonSeed
{
    public static void Seed(GSCDbContext context)
    {
        if (context.Pokemon.Any())
            return;

        var lines = File.ReadAllLines("..\\GSCMasterGuide.Infrastructure\\Seed\\SeedData\\PokemonSeedData.csv");
        lines = lines.Skip(1).ToArray();

        foreach (var line in lines)
        {
            var values = line.Split(',');

            context.Pokemon.Add(new Pokemon
            {
                Name = values[1],
                PrimaryType = (Type)Enum.Parse(typeof(Type), values[2]),
                SecondaryType = values[3] == "None" ? Type.None : (Type)Enum.Parse(typeof(Type), values[3]),
                HP = int.Parse(values[4]),
                Attack = int.Parse(values[5]),
                Defense = int.Parse(values[6]),
                SpAttack = int.Parse(values[7]),
                SpDefense = int.Parse(values[8]),
                Speed = int.Parse(values[9]),
                Tier = (Tier)Enum.Parse(typeof(Tier), values[11])
            });
        }
        context.SaveChanges();

        foreach (var line in lines)
        {
            var values = line.Split(',');

            context.Pokemon
            .First(p => p.Name == values[1])
            .PreEvolution = context.Pokemon
            .FirstOrDefault(p => p.Name == values[10]);
        }

        context.SaveChanges();
    }
}