using GSCMasterGuide.Domain.DTOs;
using MediatR;

namespace GSCMasterGuide.Infrastructure.Queries.Pokemon
{
    public class GetAllPokemonQuery : IRequest<IReadOnlyCollection<BasicPokemonDTO>> { }
}