using GSCMasterGuide.Domain.Entities;
using GSCMasterGuide.Domain.Enums;
using Type = GSCMasterGuide.Domain.Enums.Type;

namespace GSCMasterGuide.API.QueryParams
{
    public class PokemonParams
    {
        public string? Name { get; set; }

        public List<Type> Types { get; set; } = new List<Type>();

        public List<Move> MoveSet { get; set; } = new List<Move>();

        public Tier? Tier { get; set; }

        public PokemonSortBy SortBy { get; set; } = PokemonSortBy.Alphabetical;

        public SortOrder SortOrder { get; set; } = SortOrder.Ascending;
    }
}