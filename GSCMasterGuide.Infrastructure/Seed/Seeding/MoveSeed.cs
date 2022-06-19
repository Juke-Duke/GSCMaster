using GSCMasterGuide.Infrastructure.Data;
using GSCMasterGuide.Domain.Entities;

namespace GSCMasterGuide.Infrastructure.Seed.Seeding
{
    public class MoveSeed
    {
        public static void Seed(GSCDbContext context)
        {
            if (context.Moves.Any())
                return;

            var lines = File.ReadAllLines("..\\GSCMasterGuide.Infrastructure\\Seed\\SeedData\\MoveSeedData.csv");
            lines = lines.Skip(1).ToArray();

            foreach (var line in lines)
            {
                var values = line.Split(',');

                context.Moves.Add(new Move
                {
                    Name = values[0],
                    Type = (Type)Enum.Parse(typeof(Type), values[1]),
                    Category = (Category)Enum.Parse(typeof(Category), values[2]),
                    Power = int.Parse(values[3]),
                    Accuracy = int.Parse(values[4]),
                    PP = int.Parse(values[5]),
                    Priority = int.Parse(values[6]),
                    Effect = values[7],
                });
            }

            context.SaveChanges();
        }
    }
}