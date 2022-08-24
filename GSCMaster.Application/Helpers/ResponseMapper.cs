using GSCMaster.Contracts.Responses;
using GSCMaster.Core.Entities;
using Type = GSCMaster.Core.Entities.Type;

namespace GSCMaster.Application.Helpers;
public static class ResponseMapper
{
    public static PokemonResponse ToResponse(this Pokemon pokemon)
        => new PokemonResponse
        {
            NationalNumber = pokemon.NationalNumber,
            Name = pokemon.Name,
            Tier = pokemon.Tier,
            PrimaryType = pokemon.PrimaryType.ToResponse(),
            SecondaryType = pokemon.SecondaryType?.ToResponse(),
            HP = pokemon.HP,
            Attack = pokemon.Attack,
            Defense = pokemon.Defense,
            SpAttack = pokemon.SpAttack,
            SpDefense = pokemon.SpDefense,
            Speed = pokemon.Speed,
            PreEvolution = pokemon.PreEvolution?.ToResponse(),
            Evolution = pokemon.Evolution.Select(e => e.ToResponse()).ToList(),
            Moves = pokemon.Moves.Select(m => m.ToResponse()).ToList()
        };

    public static TypeResponse ToResponse(this Type type)
        => new TypeResponse
        {
            Name = type.Name,
            Effectiveness = type.Effectiveness,
            Resistances = type.Resistances,
            Pokemon = type.Pokemon.Select(p => p.ToResponse()).ToList(),
            Moves = type.Moves.Select(m => m.ToResponse()).ToList()
        };

    public static MoveResponse ToResponse(this Move move)
        => new MoveResponse
        {
            Name = move.Name,
            Type = move.Type.ToResponse(),
            Category = move.Category,
            Power = move.Power,
            Accuracy = move.Accuracy,
            PP = move.PP,
            Effect = move.Effect,
            Description = move.Description,
            Pokemon = move.Pokemon.Select(p => p.ToResponse()).ToList()
        };
}