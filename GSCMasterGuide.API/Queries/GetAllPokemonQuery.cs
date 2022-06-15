using GSCMasterGuide.Domain.DTOs;
using MediatR;

namespace GSCMasterGuide.API.Queries
{
    public class GetAllPokemonQuery : IRequest<IReadOnlyCollection<BasicPokemonDTO>>
    {
    }
}
