using FluentValidation;
using GSCMaster.Application.Services.Repositories;
using GSCMaster.Core.PokemonAggregate;
using MediatR;

namespace GSCMaster.Application.Features.PokeDex;
public sealed record GetPokemonByNameQuery(string Name) : IRequest<Pokemon?>;

public sealed class GetPokemonByNameQueryValidator : AbstractValidator<GetPokemonByNameQuery>
{
    public GetPokemonByNameQueryValidator()
    {
        RuleFor(pokemon => pokemon.Name)
            .NotNull()
            .NotEmpty();
    }
}

public sealed class GetPokemonByNameQueryHandler : IRequestHandler<GetPokemonByNameQuery, Pokemon?>
{
    private readonly IPokemonRepository _pokemonRepository;

    public GetPokemonByNameQueryHandler(IPokemonRepository pokemonRepository)
        => _pokemonRepository = pokemonRepository;

    public async Task<Pokemon?> Handle(GetPokemonByNameQuery request, CancellationToken cancellationToken)
        => await _pokemonRepository.GetPokemonByNameAsync(request.Name, cancellationToken);
}