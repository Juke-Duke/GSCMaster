using GSCMaster.Core.Enums;

namespace GSCMaster.Contracts.Responses;
public class MoveResponse
{
    public string Name { get; init; } = null!;

    public TypeResponse Type { get; init; } = null!;

    public Category Category { get; init; }

    public int Power { get; init; } = 0;

    public int Accuracy { get; init; } = 0;

    public int PP { get; init; } = 0;

    public int Priority { get; init; } = 0;

    public string Effect { get; init; } = "";

    public string Description { get; init; } = "";

    public ICollection<PokemonResponse> Pokemon { get; init; } = new List<PokemonResponse>();
}