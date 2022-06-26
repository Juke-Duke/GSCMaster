namespace GSCMasterGuide.Core.Entities;
public class PokemonTeam
{
    public int Id { get; init; }

    public Trainer Trainer { get; set; } = null!;

    public string TeamName { get; set; } = null!;

    public PokemonMember? Lead { get; set; } = null;

    public PokemonMember? Member2 { get; set; } = null;

    public PokemonMember? Member3 { get; set; } = null;

    public PokemonMember? Member4 { get; set; } = null;

    public PokemonMember? Member5 { get; set; } = null;

    public PokemonMember? Member6 { get; set; } = null;
}