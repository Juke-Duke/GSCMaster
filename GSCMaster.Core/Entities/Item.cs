using HotChocolate;
using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public sealed class Item
{
    [GraphQLIgnore]
    public ObjectId Id { get; init; }

    public string Name { get; set; } = "";

    public string Effect { get; set; } = "";

    public bool IsConsumable { get; set; } = false;
}