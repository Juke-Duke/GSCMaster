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

            var lines = File.ReadAllLines("..\\GSCMasterGuide.Infrastructure\\SeedData\\PokemonSeedData.csv");
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

        public static void SeedTest(GSCDbContext context)
        {
            if (context.Pokemon.Any())
                return;

            context.Pokemon.Add(new Pokemon
            {
                Name = "Eevee",
                PrimaryType = Type.Normal,
                SecondaryType = Type.None,
                Tier = Tier.LC,
                HP = 55,
                Attack = 55,
                Defense = 50,
                SpAttack = 45,
                SpDefense = 65,
                Speed = 55,
                PreEvolution = null
            });

            context.SaveChanges();
            context.Pokemon.Add(new Pokemon
            {
                Name = "Vaporeon",
                PrimaryType = Type.Water,
                SecondaryType = Type.None,
                Tier = Tier.OU,
                HP = 130,
                Attack = 65,
                Defense = 60,
                SpAttack = 110,
                SpDefense = 95,
                Speed = 65,
                PreEvolution = context.Pokemon.First(p => p.Name == "Eevee")
            });

            context.Pokemon.Add(new Pokemon
            {
                Name = "Jolteon",
                PrimaryType = Type.Electric,
                SecondaryType = Type.None,
                Tier = Tier.UUBL,
                HP = 65,
                Attack = 65,
                Defense = 60,
                SpAttack = 110,
                SpDefense = 95,
                Speed = 130,
                PreEvolution = context.Pokemon.First(p => p.Name == "Eevee")
            });

            context.SaveChanges();
        }
    }
}