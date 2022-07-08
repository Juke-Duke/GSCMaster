using GSCMaster.Core.Entities;
using GSCMaster.Infrastructure.Database;

namespace GSCMaster.Infrastructure.Seed.Seeding;
public class ItemSeed
{
    public static void Seed(GSCDbContext context)
    {
        if (context.Items.Any())
            return;

        var lines = File.ReadAllLines("..\\GSCMaster.Infrastructure\\Seed\\SeedData\\ItemSeedData.tsv");
        lines = lines.Skip(1).ToArray();

        foreach (var line in lines)
        {
            var values = line.Split('\t');

            context.Items.Add(new Item
            {
                Name = values[0],
                Description = values[1],
                IsConsumable = bool.Parse(values[2])
            });
        }
        context.SaveChanges();
    }
}