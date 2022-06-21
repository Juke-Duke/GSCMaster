using GSCMasterGuide.Infrastructure.Queries.Pokemon;
using GSCMasterGuide.Domain.DTOs;
using GSCMasterGuide.Domain.IRepositories;
using MediatR;

namespace GSCMasterGuide.Infrastructure.QueryHandlers.Pokemon
{
    public class GetPokemonHandler : IRequestHandler<GetPokemonQuery, FullPokemonDTO?>
    {
        private readonly IPokemonRepository _pokemonRepository;

        public GetPokemonHandler(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<FullPokemonDTO?> Handle(GetPokemonQuery request, CancellationToken cancellationToken)
            => await _pokemonRepository.Get(request.Name, cancellationToken);
    }
}