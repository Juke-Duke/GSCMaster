using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public class Type
{
    [GraphQLIgnore]
    public ObjectId Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<TypeRelation> Effectiveness { get; set; } = new List<TypeRelation>();

    public ICollection<TypeRelation> Resistances { get; set; } = new List<TypeRelation>();

    public ICollection<Pokemon> Pokemon { get; set; } = new List<Pokemon>();

    public ICollection<Move> Moves { get; set; } = new List<Move>();
}