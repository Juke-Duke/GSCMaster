using GSCMaster.Core.Enums;
using HotChocolate;
using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public sealed record TeamMember
{
    [GraphQLIgnore]
    public ObjectId Id { get; init; }

    public string? Nickname { get; set; }

    public required Pokemon Pokemon { get; set; }

    public Gender Gender { get; set; } = Gender.Random;

    public int Happiness { get; set; } = 255;

    public bool IsShiny { get; set; } = false;

    public Item? Item { get; set; } = null;

    public required Move MoveSlot1 { get; set; }

    public Move? MoveSlot2 { get; set; }

    public Move? MoveSlot3 { get; set; }

    public Move? MoveSlot4 { get; set; }

    public int HPEV { get; set; } = 252;

    public int AttackEV { get; set; } = 252;

    public int DefenseEV { get; set; } = 252;

    public int SpAttackEV { get; set; } = 252;

    public int SpDefenseEV { get; set; } = 252;

    public int SpeedEV { get; set; } = 252;

    public int HPDV { get; set; } = 15;

    public int AttackDV { get; set; } = 15;

    public int DefenseDV { get; set; } = 15;

    public int SpAttackDV { get; set; } = 15;

    public int SpDefenseDV { get; set; } = 15;

    public int SpeedDV { get; set; } = 15;
}