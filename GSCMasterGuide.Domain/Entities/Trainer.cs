using Microsoft.AspNetCore.Identity;

namespace GSCMasterGuide.Domain.Entities
{
    public class Trainer : IdentityUser<uint> // specify the data type for the Id property
    {
        // TODO remove - identityuser has passwordhash
        public string Password { get; set; } = null!;

        public DateTime CreatedAtDate { get; set; }

        public ICollection<PokemonTeam> PokemonTeams { get; set; } = new List<PokemonTeam>();
    }
}