using HotChocolate;
using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public class Item
{
    [GraphQLIgnore]
    public ObjectId Id { get; init; }

    public string Name { get; set; } = "";

    public string Effect { get; set; } = "";

    public bool IsConsumable { get; set; } = false;
}