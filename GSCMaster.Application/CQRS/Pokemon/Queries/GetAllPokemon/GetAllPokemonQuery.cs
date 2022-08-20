using HotChocolate;
using MediatR;

namespace GSCMaster.Application.CQRS.Pokemon.Queries;
public record GetAllPokemonQuery : IRequest<IReadOnlyCollection<Core.Entities.Pokemon>>;