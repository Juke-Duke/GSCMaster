namespace GSCMasterGuide.Domain.DTOs
{
    public class BasicPokemonDTO
    {
        public int NationalNumber { get; set; }

        public string Name { get; set; } = null!;

        public Type PrimaryType { get; set; } = Type.None;

        public Type SecondaryType { get; set; } = Type.None;
    }
}