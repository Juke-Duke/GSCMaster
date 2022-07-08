namespace GSCMaster.Core.DTOs;
public class FullPokemonDTO
{
    public int NationalNumber { get; set; }

    public string Name { get; set; } = null!;

    public Type PrimaryType { get; set; } = Type.None;

    public Type SecondaryType { get; set; } = Type.None;

    public Tier Tier { get; set; }

    public int HP { get; set; } = 0;

    public int Attack { get; set; } = 0;

    public int Defense { get; set; } = 0;

    public int SpAttack { get; set; } = 0;

    public int SpDefense { get; set; } = 0;

    public int Speed { get; set; } = 0;

    public IReadOnlyCollection<BasicPokemonDTO> EvolutionLine { get; set; } = null!;

    public IReadOnlyCollection<BasicMoveDTO> Moves { get; set; } = new List<BasicMoveDTO>();
}