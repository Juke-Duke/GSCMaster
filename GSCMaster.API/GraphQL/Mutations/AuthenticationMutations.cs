using GSCMaster.Application.CQRS.Authentication.Commands;
using GSCMaster.Contracts.Authentication.Requests;
using GSCMaster.Contracts.Authentication.Response;
using MapsterMapper;
using MediatR;

namespace GSCMaster.API.GraphQL.Mutations;

[ExtendObjectType(OperationTypeNames.Mutation)]
public sealed class AuthenticationMutations
{
    public async Task<AuthenticationResponse> RegisterTrainer(
        [Service] ISender mediator, [Service] IMapper mapper,
        RegisterTrainerRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(mapper.Map<RegisterTrainerCommand>(request), cancellationToken);

    public async Task<AuthenticationResponse> LoginTrainer(
        [Service] ISender mediator,
        [Service] IMapper mapper,
        LoginTrainerRequest request,
        CancellationToken cancellationToken)
        => await mediator.Send(mapper.Map<LoginTrainerCommand>(request), cancellationToken);
}