using GSCMaster.Core.Entities;

namespace GSCMaster.Contracts.Responses;
public class TypeResponse
{
    public string Name { get; init; } = null!;

    public ICollection<TypeRelation> Effectiveness { get; init; } = new List<TypeRelation>();

    public ICollection<TypeRelation> Resistances { get; init; } = new List<TypeRelation>();

    public ICollection<PokemonResponse> Pokemon { get; init; } = new List<PokemonResponse>();

    public ICollection<MoveResponse> Moves { get; init; } = new List<MoveResponse>();
}