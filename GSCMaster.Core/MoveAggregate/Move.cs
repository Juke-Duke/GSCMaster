using GSCMaster.Core.Common.Primitives;
using GSCMaster.Core.MoveAggregate.Enums;
using GSCMaster.Core.PokemonAggregate;
using MongoDB.Bson;

namespace GSCMaster.Core.MoveAggregate;
public sealed class Move : AggregateRoot
{
    public string Name { get; }

    public Type Type { get; }

    public Category Category { get; }

    public int Power { get; }

    public float Accuracy { get; }

    public int PP { get; }

    public int Priority { get; }

    public string Effect { get; }

    public IReadOnlyCollection<Pokemon> Learnset { get; }

    public Move(
        string name,
        Type type,
        Category category,
        int power,
        float accuracy,
        int pp,
        int priority,
        string effect,
        IList<Pokemon> learnset)
        : base(ObjectId.GenerateNewId())
    {
        Name = name;
        Type = type;
        Category = category;
        Power = power;
        Accuracy = accuracy;
        PP = pp;
        Priority = priority;
        Effect = effect;
        Learnset = learnset.AsReadOnly();
    }
}