using GSCMaster.Core.Common.Primitives;
using GSCMaster.Core.Common.Primitives.Enums;
using GSCMaster.Core.ItemAggregate;
using GSCMaster.Core.MoveAggregate;
using GSCMaster.Core.PokemonAggregate;
using GSCMaster.Core.TeamMemberAggregate.ValueObjects;
using MongoDB.Bson;

namespace GSCMaster.Core.TeamMemberAggregate;
public class TeamMember : AggregateRoot
{
    public Pokemon Pokemon { get; }

    public string? Nickname { get; }

    public Gender Gender { get; }

    public byte Happiness { get; }

    public bool IsShiny { get; }

    public Item? Item { get; }

    public EV HPEV { get; }

    public EV AttackEV { get; }

    public EV DefenseEV { get; }

    public EV SpecialAttackEV { get; }

    public EV SpecialDefenseEV { get; }

    public EV SpeedEV { get; }

    public DV HPDV { get; }

    public DV AttackDV { get; }

    public DV DefenseDV { get; }

    public DV SpecialAttackDV { get; }

    public DV SpecialDefenseDV { get; }

    public DV SpeedDV { get; }

    public ICollection<Move> Moveset { get; }

    public DateTime ModifiedOn { get; }

    public TeamMember(
        Pokemon pokemon,
        string? nickname,
        Gender gender,
        byte happiness,
        bool isShiny,
        Item? item,
        ICollection<Move> moveset,
        EV hpEV,
        EV attackEV,
        EV defenseEV,
        EV specialAttackEV,
        EV specialDefenseEV,
        EV speedEV,
        DV hpDV,
        DV attackDV,
        DV defenseDV,
        DV specialAttackDV,
        DV specialDefenseDV,
        DV speedDV,
        DateTime modifiedOn)
        : base(ObjectId.GenerateNewId())
    {
        Pokemon = pokemon;
        Nickname = nickname;
        Gender = gender;
        Happiness = happiness;
        IsShiny = isShiny;
        Item = item;
        Moveset = moveset;
        HPEV = hpEV;
        AttackEV = attackEV;
        DefenseEV = defenseEV;
        SpecialAttackEV = specialAttackEV;
        SpecialDefenseEV = specialDefenseEV;
        SpeedEV = speedEV;
        HPDV = hpDV;
        AttackDV = attackDV;
        DefenseDV = defenseDV;
        SpecialAttackDV = specialAttackDV;
        SpecialDefenseDV = specialDefenseDV;
        SpeedDV = speedDV;
        ModifiedOn = modifiedOn;
    }
}