using GSCMaster.Core.Common.Enums;
using GSCMaster.Core.Common.Primitives.Enums;
using GSCMaster.Core.MoveAggregate;
using GSCMaster.Core.PokemonAggregate;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Seeding;
public static partial class Seeder
{
    public static async void SeedPokemon(this GSCMasterDBConnection db)
    {
        if (db.Pokemon.CountDocuments(new BsonDocument()) > 0)
            return;

        var lines = File.ReadAllLines(@"..\GSCMaster.Infrastructure\Seeding\SeedData\PokemonSeedData.tsv")
                        .Skip(1)
                        .ToArray();

        foreach (var line in lines)
        {
            var values = line.Split('\t');

            db.Pokemon.InsertOne(new Pokemon
            (
                nationalNumber: byte.Parse(values[0]),
                name: values[1],
                tier: (Tier)Enum.Parse(typeof(Tier), values[2]),
                primaryType: await db.Types.FindAsync(type => type.Identifier == values[3]).Result.FirstOrDefaultAsync(),
                secondaryType: values[4] == "None" ? null : await db.Types.FindAsync(type => type.Identifier == values[4]).Result.FirstOrDefaultAsync(),
                baseHP: byte.Parse(values[6]),
                baseAttack: byte.Parse(values[7]),
                baseDefense: byte.Parse(values[8]),
                baseSpecialAttack: byte.Parse(values[9]),
                baseSpecialDefense: byte.Parse(values[10]),
                baseSpeed: byte.Parse(values[11]),
                defaultGender: (Gender)Enum.Parse(typeof(Gender), values[12]),
                preEvolution: values[5] == "None" ? null : await db.Pokemon.FindAsync(pokemon => pokemon.Name == values[5]).Result.FirstOrDefaultAsync(),
                evolution: new List<Pokemon>(),
                movepool: new List<Move>()
            ));
        }
    }
}