using GSCMaster.Core.Entities;
using GSCMaster.Infrastructure.Database;
using MongoDB.Bson;
using MongoDB.Driver;
using Type = GSCMaster.Core.Entities.Type;

namespace GSCMaster.Infrastructure.Seeding;
public static partial class Seeder
{
    public static void SeedTypes(GSCMasterDbContext db)
    {
        if (db.Types.CountDocuments(new BsonDocument()) > 0)
            return;

        var lines = File.ReadAllLines(@"..\GSCMaster.Infrastructure\Seeding\\SeedData\TypeSeedData.tsv");
        lines = lines.Skip(1).ToArray();

        foreach (var line in lines)
        {
            var values = line.Split('\t');

            db.Types.InsertOne(new Type
            {
                Name = values[0]
            });

            Console.WriteLine($"{values[0]} added to database");
        }

        List<string[]> matchups = new List<string[]>();

        lines = File.ReadAllLines(@"..\GSCMaster.Infrastructure\Seeding\SeedData\TypeSeedData.tsv");
        lines = lines.ToArray();

        foreach (var line in lines)
        {
            var values = line.Split('\t');
            matchups.Add(values);
        }

        const int MAX_TYPES = 18;

        for (int i = 1; i < MAX_TYPES; ++i)
        {
            for (int j = 1; j < MAX_TYPES; ++j)
            {
                var multiplier = float.Parse(matchups[i][j]);
                var offensiveType = db.Types.Find(t => t.Name == matchups[i][0]).FirstOrDefault();
                var defensiveType = db.Types.Find(t => t.Name == matchups[0][j]).FirstOrDefault();

                offensiveType.Effectiveness[defensiveType.Id] = multiplier;
                defensiveType.Resistances[offensiveType.Id] = multiplier;

                var filterOffensiveType = Builders<Type>.Filter
                    .Eq(t => t.Name, offensiveType.Name);

                var updateOffensiveType = Builders<Type>.Update
                    .Set(t => t.Effectiveness, offensiveType.Effectiveness);

                db.Types.UpdateOne(filterOffensiveType, updateOffensiveType);

                var filterDefensiveType = Builders<Type>.Filter
                    .Eq(t => t.Name, defensiveType.Name);

                var updateDefensiveType = Builders<Type>.Update
                    .Set(t => t.Resistances, defensiveType.Resistances);

                db.Types.UpdateOne(filterDefensiveType, updateDefensiveType);
            }
        }
    }
}