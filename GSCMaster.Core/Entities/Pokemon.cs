using GSCMaster.Core.Enums;
using HotChocolate;
using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public class Pokemon
{
    [GraphQLIgnore]
    public ObjectId Id { get; set; }

    public int NationalNumber { get; init; }

    public string Name { get; set; } = default!;

    public Tier Tier { get; set; } = Tier.OU;

    public Type PrimaryType { get; set; } = default!;

    public Type? SecondaryType { get; set; }

    [GraphQLName("hp")]
    public int HP { get; set; } = 0;

    public int Attack { get; set; } = 0;

    public int Defense { get; set; } = 0;

    public int SpAttack { get; set; } = 0;

    public int SpDefense { get; set; } = 0;

    public int Speed { get; set; } = 0;

    public Pokemon? PreEvolution { get; set; } = default!;

    public ICollection<Pokemon> Evolution { get; set; } = new List<Pokemon>();

    public ICollection<Move> Moves { get; set; } = new List<Move>();
}