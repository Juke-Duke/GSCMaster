namespace GSCMasterGuide.Domain.Entities
{
    public class PokemonTeam
    {
        public int Id { get; init; }

        // public Trainer Trainer { get; set; } = null!;

        public string TeamName { get; set; } = null!;

        public uint? LeadId { get; init; }
        public PokemonMember? Lead { get; set; }

        public uint? Member2Id { get; set; }
        public PokemonMember? Member2 { get; set; }

        public uint? Member3Id { get; init; }
        public PokemonMember? Member3 { get; set; }

        public uint? Member4Id { get; init; }
        public PokemonMember? Member4 { get; set; }

        public uint? Member5Id { get; init; }
        public PokemonMember? Member5 { get; set; }

        public uint? Member6Id { get; init; }
        public PokemonMember? Member6 { get; set; }
    }
}