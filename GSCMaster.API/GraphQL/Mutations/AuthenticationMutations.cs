using GSCMaster.Application.Features.Authentication;
using GSCMaster.Core.Common.Primitives;
using MapsterMapper;
using MediatR;

namespace GSCMaster.API.GraphQL.Mutations;

[MutationType]
public static class AuthenticationMutations
{
    public static async Task<ErrorProne<AuthenticationResponse>> RegisterTrainer(
        [Service] ISender mediator, [Service] IMapper mapper,
        RegisterTrainerCommand request,
        CancellationToken cancellationToken)
        => await mediator.Send(request, cancellationToken);

    public static async Task<ErrorProne<AuthenticationResponse>> LoginTrainer(
        [Service] ISender mediator,
        [Service] IMapper mapper,
        LoginTrainerCommand request,
        CancellationToken cancellationToken)
        => await mediator.Send(mapper.Map<LoginTrainerCommand>(request), cancellationToken);
}