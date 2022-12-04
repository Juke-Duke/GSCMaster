using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public sealed class Item
{
    public ObjectId Id { get; init; }

    public required string Name { get; set; }

    public required string Effect { get; set; }

    public required bool IsConsumable { get; set; }
}