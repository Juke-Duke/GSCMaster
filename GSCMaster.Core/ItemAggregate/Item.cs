using GSCMaster.Core.Common.Primitives;
using MongoDB.Bson;

namespace GSCMaster.Core.ItemAggregate;
public class Item : AggregateRoot
{
    public string Name { get; }

    public string Effect { get; }

    public bool IsConsumable { get; }

    public Item(
        string name,
        string effect,
        bool isConsumable)
        : base(ObjectId.GenerateNewId())
    {
        Name = name;
        Effect = effect;
        IsConsumable = isConsumable;
    }
}