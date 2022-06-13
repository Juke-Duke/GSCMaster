namespace GSCMasterGuide.Domain.Entities
{
    public class PokemonMove
    {
        public int NationalNumber { get; init; }
        public Pokemon Pokemon { get; set; } = null!;

        public int MoveId { get; init; }
        public Move Move { get; set; } = null!;
    }
}