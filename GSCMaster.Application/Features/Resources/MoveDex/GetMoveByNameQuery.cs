using FluentValidation;
using GSCMaster.Application.Services.Repositories;
using GSCMaster.Core.MoveAggregate;
using MediatR;

namespace GSCMaster.Application.Features.Resources.MoveDex;
public sealed record GetMoveByNameQuery(string Name) : IRequest<Move?>;

public sealed class GetMoveByNameQueryValidator : AbstractValidator<GetMoveByNameQuery>
{
    public GetMoveByNameQueryValidator()
    {
        RuleFor(move => move.Name)
            .NotNull()
            .NotEmpty();
    }
}

public sealed class GetMoveByNameQueryHandler : IRequestHandler<GetMoveByNameQuery, Move?>
{
    private readonly IMoveRepository _moveRepository;

    public GetMoveByNameQueryHandler(IMoveRepository moveRepository)
        => _moveRepository = moveRepository;

    public async Task<Move?> Handle(GetMoveByNameQuery request, CancellationToken cancellationToken)
        => await _moveRepository.GetMoveByNameAsync(request.Name, cancellationToken);
}