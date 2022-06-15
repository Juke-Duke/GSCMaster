namespace GSCMasterGuide.Domain.Entities
{
    public class Trainer
    {   
        public uint Id { get; set; }

        public string Email { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public ICollection<PokemonTeam> PokemonTeams { get; set; } = new List<PokemonTeam>();
    }
}