using GSCMaster.Core.Common.Enums;
using GSCMaster.Core.Common.Primitives;
using GSCMaster.Core.Common.Primitives.Enums;
using GSCMaster.Core.MoveAggregate;
using MongoDB.Bson;

namespace GSCMaster.Core.PokemonAggregate;
public sealed class Pokemon : AggregateRoot
{
    public byte NationalNumber { get; }

    public string Name { get; }

    public Tier Tier { get; }

    public Type PrimaryType { get; }

    public Type? SecondaryType { get; }

    public Gender DefaultGender { get; }

    public byte BaseHP { get; }

    public byte BaseAttack { get; }

    public byte BaseDefense { get; }

    public byte BaseSpecialAttack { get; }

    public byte BaseSpecialDefense { get; }

    public byte BaseSpeed { get; }

    public int BST => BaseHP + BaseAttack + BaseDefense + BaseSpecialAttack + BaseSpecialDefense + BaseSpeed;

    public Pokemon? PreEvolution { get; }

    public IReadOnlyCollection<Pokemon> Evolution { get; }

    public IReadOnlyCollection<Move> Movepool { get; }

    public Pokemon(
        byte nationalNumber,
        string name,
        Tier tier,
        Type primaryType,
        Type? secondaryType,
        Gender defaultGender,
        byte baseHP,
        byte baseAttack,
        byte baseDefense,
        byte baseSpecialAttack,
        byte baseSpecialDefense,
        byte baseSpeed,
        Pokemon? preEvolution,
        IList<Pokemon> evolution,
        IList<Move> movepool)
        : base(ObjectId.GenerateNewId())
    {
        NationalNumber = nationalNumber;
        Name = name;
        Tier = tier;
        PrimaryType = primaryType;
        SecondaryType = secondaryType;
        DefaultGender = defaultGender;
        BaseHP = baseHP;
        BaseAttack = baseAttack;
        BaseDefense = baseDefense;
        BaseSpecialAttack = baseSpecialAttack;
        BaseSpecialDefense = baseSpecialDefense;
        BaseSpeed = baseSpeed;
        PreEvolution = preEvolution;
        Evolution = evolution.AsReadOnly();
        Movepool = movepool.AsReadOnly();
    }
}