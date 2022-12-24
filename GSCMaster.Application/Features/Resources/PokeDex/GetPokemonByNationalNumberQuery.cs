using FluentValidation;
using GSCMaster.Application.Services.Repositories;
using GSCMaster.Core.PokemonAggregate;
using MediatR;

namespace GSCMaster.Application.Features.PokeDex;
public sealed record GetPokemonByNationalNumberQuery(byte NationalNumber) : IRequest<Pokemon?>;

public sealed class GetPokemonByNationalNumberQueryValidator : AbstractValidator<GetPokemonByNationalNumberQuery>
{
    public GetPokemonByNationalNumberQueryValidator()
    {
        
    }
}

public sealed class GetPokemonByNationalNumberQueryHandler : IRequestHandler<GetPokemonByNationalNumberQuery, Pokemon?>
{
    private readonly IPokemonRepository _pokemonRepository;

    public GetPokemonByNationalNumberQueryHandler(IPokemonRepository pokemonRepository)
        => _pokemonRepository = pokemonRepository;

    public async Task<Pokemon?> Handle(GetPokemonByNationalNumberQuery request, CancellationToken cancellationToken)
        => await _pokemonRepository.GetPokemonByNationalNumberAsync(request.NationalNumber, cancellationToken);
}