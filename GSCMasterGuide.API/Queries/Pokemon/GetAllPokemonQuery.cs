using GSCMasterGuide.Domain.DTOs;
using MediatR;

namespace GSCMasterGuide.API.Queries.Pokemon
{
    public class GetAllPokemonQuery : IRequest<IReadOnlyCollection<BasicPokemonDTO>> {}
}