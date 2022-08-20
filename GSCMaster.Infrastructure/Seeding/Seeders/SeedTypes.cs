using GSCMaster.Core.Entities;
using GSCMaster.Infrastructure.Database;
using MongoDB.Bson;
using MongoDB.Driver;
using Type = GSCMaster.Core.Entities.Type;

namespace GSCMaster.Infrastructure.Seeding;
public static partial class Seeder
{
    public static void SeedTypes(GSCMasterDBContext db)
    {
        if (db.Types.CountDocuments(new BsonDocument()) > 0)
            return;

        var lines = File.ReadAllLines("..\\GSCMaster.Infrastructure\\Seeding\\SeedData\\TypeSeedData.tsv");
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

        lines = File.ReadAllLines("..\\GSCMaster.Infrastructure\\Seeding\\SeedData\\TypeSeedData.tsv");
        lines = lines.ToArray();

        foreach (var line in lines)
        {
            var values = line.Split('\t');
            matchups.Add(values);
        }

        for (int i = 1; i < 18; ++i)
        {
            List<TypeRelation> effectiveness = new List<TypeRelation>();
            List<TypeRelation> resistances = new List<TypeRelation>();
            var filter = Builders<Type>.Filter.Eq(t => t.Name, matchups[i][0]);
            var type = db.Types.Find(filter).FirstOrDefault();

            for (int j = 1; j < 18; ++j)
            {
                effectiveness.Add(new TypeRelation
                {
                    Type = db.Types
                        .Find(Builders<Type>.Filter
                        .Eq(t => t.Name, matchups[j][0]))
                        .FirstOrDefault().Id,
                    Name = matchups[j][0],
                    Multiplier = float.Parse(matchups[i][j])
                });

                resistances.Add(new TypeRelation
                {
                    Type = db.Types
                        .Find(Builders<Type>.Filter
                        .Eq(t => t.Name, matchups[j][0]))
                        .FirstOrDefault().Id,
                    Name = matchups[j][0],
                    Multiplier = float.Parse(matchups[j][i])
                });
            }

            var update = Builders<Type>.Update
                .Set(t => t.Effectiveness, effectiveness)
                .Set(t => t.Resistances, resistances);

            db.Types.UpdateOne(filter, update);
        }

        var pokemon = db.Pokemon.Find(new BsonDocument()).ToList();

        lines = File.ReadAllLines("..\\GSCMaster.Infrastructure\\Seeding\\SeedData\\PokemonSeedData.tsv");
        lines = lines.Skip(1).ToArray();

        foreach (var line in lines)
        {
            var values = line.Split('\t');

            var filter = Builders<Pokemon>.Filter.Eq(p => p.Name, values[1]);

            var update = Builders<Pokemon>.Update
                .Set(p => p.PrimaryType, db.Types
                    .Find(t => t.Name == values[3])
                    .FirstOrDefault())
                .Set(p => p.SecondaryType, db.Types
                    .Find(t => t.Name == values[4])
                    .FirstOrDefault());

            db.Pokemon.UpdateOne(filter, update);
            Console.WriteLine($"{values[1]} updated");
        }
    }
}