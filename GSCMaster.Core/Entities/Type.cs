using HotChocolate;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace GSCMaster.Core.Entities;
public sealed record Type
{
    [GraphQLIgnore]
    public ObjectId Id { get; set; }

    public required string Name { get; set; }

    [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
    public Dictionary<ObjectId, float> Effectiveness { get; set; } = new();

    [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
    public Dictionary<ObjectId, float> Resistances { get; set; } = new();

    public ICollection<Pokemon> Pokemon { get; set; } = new List<Pokemon>();

    public ICollection<Move> Moves { get; set; } = new List<Move>();
}