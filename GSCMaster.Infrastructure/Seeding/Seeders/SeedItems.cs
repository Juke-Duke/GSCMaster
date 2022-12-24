using GSCMaster.Core.ItemAggregate;

using MongoDB.Bson;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Seeding;
public static partial class Seeder
{
    public static void SeedItems(this GSCMasterDBConnection db)
    {
        if (db.Items.CountDocuments(new BsonDocument()) > 0)
            return;

        var lines = File.ReadAllLines(@"..\GSCMaster.Infrastructure\Seeding\SeedData\ItemSeedData.tsv");
        lines = lines.Skip(1).ToArray();

        foreach (var line in lines)
        {
            var values = line.Split('\t');

            db.Items.InsertOne(new Item
            (
                name: values[0],
                effect: values[1],
                isConsumable: bool.Parse(values[2])
            ));

            Console.WriteLine($"{values[0]} added to database");
        }
    }
}