using FluentValidation;
using GSCMaster.Application.Repositories;
using MediatR;

namespace GSCMaster.Application.CQRS.Pokemon.Queries;
public sealed record GetPokemonByNameQuery(string Name) : IRequest<Core.Entities.Pokemon?>;

public sealed class GetPokemonByNameQueryValidator : AbstractValidator<GetPokemonByNameQuery>
{
    public GetPokemonByNameQueryValidator()
    {
        RuleFor(pokemon => pokemon.Name)
            .NotNull()
            .NotEmpty();
    }
}

public sealed class GetPokemonByNameQueryHandler : IRequestHandler<GetPokemonByNameQuery, Core.Entities.Pokemon?>
{
    private readonly IPokemonRepository _pokemonRepository;

    public GetPokemonByNameQueryHandler(IPokemonRepository pokemonRepository)
        => _pokemonRepository = pokemonRepository;

    public async Task<Core.Entities.Pokemon?> Handle(GetPokemonByNameQuery request, CancellationToken cancellationToken)
        => await _pokemonRepository.GetPokemonByNameAsync(request.Name, cancellationToken);
}