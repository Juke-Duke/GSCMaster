using System.ComponentModel.DataAnnotations;

namespace GSCMasterGuide.Domain.Entities
{
    public class Pokemon
    {
        [Key] public int NationalNumber { get; init; }

        public string Name { get; set; } = null!;

        public Type PrimaryType { get; set; } = Type.None;

        public Type SecondaryType { get; set; } = Type.None;

        public Tier Tier { get; set; }

        public int HP { get; set; } = 0;

        public int Attack { get; set; } = 0;

        public int Defense { get; set; } = 0;

        public int SpAttack { get; set; } = 0;

        public int SpDefense { get; set; } = 0;

        public int Speed { get; set; } = 0;

        public int? PreEvolution { get; set; }

        public ICollection<Pokemon>? Evolutions { get; set; }

        public ICollection<Move> Moves { get; set; } = new List<Move>();
    }
}