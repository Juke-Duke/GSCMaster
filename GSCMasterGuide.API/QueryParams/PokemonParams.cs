namespace GSCMasterGuide.API.QueryParams
{
    public class PokemonParams
    {
        public string? Name { get; set; }

        public List<Type> Types { get; set; } = new List<Type>();

        public Tier? Tier { get; set; }

        public PokemonSortBy SortBy { get; set; } = PokemonSortBy.Alphabetical;

        public SortOrder SortOrder { get; set; } = SortOrder.Ascending;
    }
}
