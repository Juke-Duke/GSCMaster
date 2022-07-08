using Microsoft.AspNetCore.Identity;

namespace GSCMaster.Core.Entities;
public class Trainer : IdentityUser<uint>
{
    // TODO remove - identityuser has passwordhash
    public string Password { get; set; } = null!;

    public DateTime CreatedAtDate { get; set; }

    public ICollection<PokemonTeam> PokemonTeams { get; set; } = new List<PokemonTeam>();
}