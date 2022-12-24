using MongoDB.Bson;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Seeding;
public static partial class Seeder
{
    public static void SeedTypes(this GSCMasterDBConnection db)
    {
        if (db.Types.CountDocuments(new BsonDocument()) > 0)
            return;

        var lines = File.ReadAllLines(@"..\GSCMaster.Infrastructure\Seeding\\SeedData\TypeSeedData.tsv");
        lines = lines.Skip(1).ToArray();

        foreach (var line in lines)
        {
            var values = line.Split('\t');

            Type.TryParse(values[0], out var type);

            db.Types.InsertOne(type!);

            Console.WriteLine($"{values[0]} added to database");
        }
    }
}