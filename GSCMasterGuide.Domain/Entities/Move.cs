namespace GSCMasterGuide.Domain.Entities
{
    public class Move
    {
        public int Id { get; init; }

        public string Name { get; set; } = null!;

        public Type Type { get; set; } = Type.None;

        public Category Category { get; set; }

        public int Power { get; set; } = 0;

        public int Accuracy { get; set; } = 0;

        public int PP { get; set; } = 0;

        public int Priority { get; set; } = 0;

        public string Effect { get; set; } = "";

        public string Description { get; set; } = "";

        public ICollection<Pokemon> EligiblePokemon { get; set; } = new List<Pokemon>();
    }
}