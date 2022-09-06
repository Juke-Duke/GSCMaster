using GSCMaster.Core.Enums;
using HotChocolate;
using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public class Move
{
    [GraphQLIgnore]
    public ObjectId Id { get; init; }

    public string Name { get; set; } = null!;

    public Type Type { get; set; } = null!;

    public Category Category { get; set; }

    public int Power { get; set; } = 0;

    public int Accuracy { get; set; } = 0;

    [GraphQLName("pp")]
    public int PP { get; set; } = 0;

    public int Priority { get; set; } = 0;

    public string Effect { get; set; } = "";

    public string Description { get; set; } = "";

    public ICollection<Pokemon> Pokemon { get; set; } = new List<Pokemon>();
}