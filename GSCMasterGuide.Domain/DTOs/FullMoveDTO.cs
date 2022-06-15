namespace GSCMasterGuide.Domain.DTOs
{
    public class FullMoveDTO
    {
        public string Name { get; set; } = null!;

        public Type Type { get; set; } = Type.None;

        public Category Category { get; set; }

        public int Power { get; set; } = 0;

        public int Accuracy { get; set; } = 0;

        public int PP { get; set; } = 0;

        public int Priority { get; set; } = 0;

        public string Effect { get; set; } = null!;

        public string Description { get; set; } = null!;

        public IReadOnlyCollection<BasicPokemonDTO> EligiblePokemon { get; set; } = new List<BasicPokemonDTO>();
    }
}