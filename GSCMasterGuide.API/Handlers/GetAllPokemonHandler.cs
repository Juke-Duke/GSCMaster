
using GSCMasterGuide.Domain.DTOs;
using GSCMasterGuide.Domain.IRepositories;
using GSCMasterGuide.API.Queries;
using MediatR;

namespace GSCMasterGuide.API.Handlers
{
    public class GetAllPokemonHandler : IRequestHandler<GetAllPokemonQuery, IReadOnlyCollection<BasicPokemonDTO>>
    {
        private readonly IPokemonRepository _pokemonRepository;

        public GetAllPokemonHandler(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<IReadOnlyCollection<BasicPokemonDTO>> Handle(GetAllPokemonQuery request, CancellationToken cancellationToken)
            => await _pokemonRepository.GetAll();
    }
}
