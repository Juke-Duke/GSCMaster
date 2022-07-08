using GSCMaster.Core.DTOs;
using MediatR;

namespace GSCMaster.Core.Queries.Pokemon;
public class GetAllPokemonQuery : IRequest<IReadOnlyCollection<BasicPokemonDTO>> { }