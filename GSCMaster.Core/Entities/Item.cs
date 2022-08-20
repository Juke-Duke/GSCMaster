using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public class Item
{
    [GraphQLIgnore]
    public ObjectId Id { get; init; }

    public string Name { get; set; } = null!;

    public string Effect { get; set; } = null!;

    public bool IsConsumable { get; set; } = false;
}