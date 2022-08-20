using HotChocolate;
using MediatR;

namespace GSCMaster.Application.CQRS.Pokemon.Queries;
public record GetPokemonQuery(string Name) : IRequest<Core.Entities.Pokemon?>;