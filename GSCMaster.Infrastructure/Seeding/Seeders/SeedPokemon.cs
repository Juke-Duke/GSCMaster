using GSCMaster.Core.Entities;
using GSCMaster.Core.Enums;
using GSCMaster.Infrastructure.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Seeding;
public static partial class Seeder
{
    public static async void SeedPokemon(GSCMasterDbContext db)
    {
        if (db.Pokemon.CountDocuments(new BsonDocument()) > 0)
            return;

        var lines = File.ReadAllLines(@"..\GSCMaster.Infrastructure\Seeding\SeedData\PokemonSeedData.tsv");
        lines = lines.Skip(1).ToArray();

        foreach (var line in lines)
        {
            var values = line.Split('\t');

            db.Pokemon.InsertOne(new Pokemon
            {
                NationalNumber = int.Parse(values[0]),
                Name = values[1],
                Tier = (Tier)Enum.Parse(typeof(Tier), values[2]),
                PrimaryType = await db.Types.FindAsync(type => type.Name == values[3]).Result.FirstOrDefaultAsync(),
                SecondaryType = values[4] == "None" ? null : await db.Types.FindAsync(type => type.Name == values[4]).Result.FirstOrDefaultAsync(),
                HP = int.Parse(values[6]),
                Attack = int.Parse(values[7]),
                Defense = int.Parse(values[8]),
                SpAttack = int.Parse(values[9]),
                SpDefense = int.Parse(values[10]),
                Speed = int.Parse(values[11])
            });
        }
    }
}