using GSCMasterGuide.Domain.DTOs;
using GSCMasterGuide.Domain.IRepositories;
using GSCMasterGuide.Infrastructure.Queries.Pokemon;
using MediatR;

namespace GSCMasterGuide.Infrastructure.QueryHandlers
{
    public class GetAllPokemonHandler : IRequestHandler<GetAllPokemonQuery, IReadOnlyCollection<BasicPokemonDTO>>
    {
        private readonly IPokemonRepository _pokemonRepository;

        public GetAllPokemonHandler(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<IReadOnlyCollection<BasicPokemonDTO>> Handle(GetAllPokemonQuery request, CancellationToken cancellationToken)
            => await _pokemonRepository.GetAll(cancellationToken);
    }
}