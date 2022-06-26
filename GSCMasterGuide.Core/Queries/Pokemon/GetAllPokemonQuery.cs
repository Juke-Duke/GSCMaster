using GSCMasterGuide.Core.DTOs;
using MediatR;

namespace GSCMasterGuide.Core.Queries.Pokemon;
public class GetAllPokemonQuery : IRequest<IReadOnlyCollection<BasicPokemonDTO>> {}