using GSCMaster.Core.Entities;
using GSCMaster.Core.Enums;
using GSCMaster.Infrastructure.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Seeding;
public static partial class Seeder
{
    public static void SeedPokemon(GSCMasterDBContext db)
    {
        if (db.Pokemon.CountDocuments(new BsonDocument()) > 0)
            return;

        var lines = File.ReadAllLines("..\\GSCMaster.Infrastructure\\Seeding\\SeedData\\PokemonSeedData.tsv");
        lines = lines.Skip(1).ToArray();

        foreach (var line in lines)
        {
            var values = line.Split('\t');

            db.Pokemon.InsertOne(new Pokemon
            {
                NationalNumber = int.Parse(values[0]),
                Name = values[1],
                Tier = (Tier)Enum.Parse(typeof(Tier), values[2]),
                HP = int.Parse(values[6]),
                Attack = int.Parse(values[7]),
                Defense = int.Parse(values[8]),
                SpAttack = int.Parse(values[9]),
                SpDefense = int.Parse(values[10]),
                Speed = int.Parse(values[11])
            });

            Console.WriteLine($"{values[1]} added to database");
        }

        Seeder.SeedTypes(db);

        foreach (var line in lines)
        {
            var values = line.Split('\t');

            var filter = Builders<Pokemon>.Filter.Eq(p => p.Name, values[1]);

            var update = Builders<Pokemon>.Update
                .Set(p => p.PreEvolution, db.Pokemon
                .Find(p => p.Name == values[5])
                .FirstOrDefault());

            db.Pokemon.UpdateOne(filter, update);
        }
    }
}