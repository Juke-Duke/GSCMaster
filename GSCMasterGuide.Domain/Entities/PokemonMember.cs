namespace GSCMasterGuide.Domain.Entities
{
    public class PokemonMember
    {
        public uint Id { get; init; }

        public string? Nickname { get; set; }

        public int NationalNumber { get; init; }
        public Pokemon Pokemon { get; set; } = null!;

        public Gender Gender { get; set; } = Gender.Genderless;

        public int Happiness { get; set; } = 255;

        public bool IsShiny { get; set; } = false;

        public int ItemId { get; init; }
        public Item? Item { get; set; }

        public int MoveSlot1Id { get; init; }
        public Move? MoveSlot1 { get; set; }

        public int MoveSlot2Id { get; init; }
        public Move? MoveSlot2 { get; set; }

        public int MoveSlot3Id { get; init; }
        public Move? MoveSlot3 { get; set; }

        public int MoveSlot4Id { get; init; }
        public Move? MoveSlot4 { get; set; }

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
}