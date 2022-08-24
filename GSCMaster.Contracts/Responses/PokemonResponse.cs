using GSCMaster.Core.Enums;

namespace GSCMaster.Contracts.Responses;
public class PokemonResponse
{
    public int NationalNumber { get; init; }

    public string Name { get; init; } = null!;

    public Tier Tier { get; init; } = Tier.OU;

    public TypeResponse PrimaryType { get; init; } = null!;

    public TypeResponse? SecondaryType { get; init; }

    public int HP { get; init; } = 0;

    public int Attack { get; init; } = 0;

    public int Defense { get; init; } = 0;

    public int SpAttack { get; init; } = 0;

    public int SpDefense { get; init; } = 0;

    public int Speed { get; init; } = 0;

    public PokemonResponse? PreEvolution { get; init; } = null;

    public ICollection<PokemonResponse> Evolution { get; init; } = new List<PokemonResponse>();

    public ICollection<MoveResponse> Moves { get; init; } = new List<MoveResponse>();
}