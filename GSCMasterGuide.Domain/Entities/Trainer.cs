using Microsoft.AspNetCore.Identity;

namespace GSCMasterGuide.Domain.Entities
{
    public class Trainer : IdentityUser<uint>
    {   
        public string ProfilePictureUrl { get; set; } = null!;

        public ICollection<PokemonTeam> PokemonTeams { get; set; } = new List<PokemonTeam>();
    }
}