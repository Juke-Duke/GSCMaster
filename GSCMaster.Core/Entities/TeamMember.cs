using GSCMaster.Core.Enums;
using HotChocolate;
using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public class TeamMember
{
    [GraphQLIgnore]
    public ObjectId Id { get; init; }

    public string? Nickname { get; set; } = null;

    public Pokemon Pokemon { get; set; } = null!;

    public Gender Gender { get; set; } = Gender.Genderless;

    public int Happiness { get; set; } = 255;

    public bool IsShiny { get; set; } = false;

    public Item? Item { get; set; } = null;

    public Move MoveSlot1 { get; set; } = null!;

    public Move? MoveSlot2 { get; set; } = null;

    public Move? MoveSlot3 { get; set; } = null;

    public Move? MoveSlot4 { get; set; } = null;

    public int HPEV { get; set; } = 252;

    public int AttackEV { get; set; } = 252;

    public int DefenseEV { get; set; } = 252;

    public int SpAttackEV { get; set; } = 252;

    public int SpDefenseEV { get; set; } = 252;

    public int SpeedEV { get; set; } = 252;

    public int HPIV { get; set; } = 30;

    public int AttackIV { get; set; } = 30;

    public int DefenseIV { get; set; } = 30;

    public int SpAttackIV { get; set; } = 30;

    public int SpDefenseIV { get; set; } = 30;

    public int SpeedIV { get; set; } = 30;
}