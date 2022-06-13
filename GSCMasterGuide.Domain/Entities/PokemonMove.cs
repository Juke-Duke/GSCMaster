namespace GSCMasterGuide.Domain.Entities
{
    public class PokemonMove
    {
        public Pokemon Pokemon { get; set; } = null!;

        public Move Move { get; set; } = null!;
    }
}