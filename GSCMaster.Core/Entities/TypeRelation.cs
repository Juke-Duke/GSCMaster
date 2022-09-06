using HotChocolate;
using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public class TypeRelation
{
    [GraphQLIgnore]
    public ObjectId Type { get; set; }

    public string Name { get; set; } = null!;

    public float Multiplier { get; set; }
}