using FluentValidation;
using GSCMaster.Application.Repositories;
using GSCMaster.Core.Entities;
using MediatR;

namespace GSCMaster.Application.CQRS.Items.Queries;
public sealed record GetItemByNameQuery(string Name) : IRequest<Item?>;

public sealed class GetItemByNameQueryValidator : AbstractValidator<GetItemByNameQuery>
{
    public GetItemByNameQueryValidator()
    {
        RuleFor(item => item.Name)
            .NotNull()
            .NotEmpty();
    }
}

public sealed class GetItemByNameQueryHandler : IRequestHandler<GetItemByNameQuery, Item?>
{
    private readonly IItemRepository _itemRepository;

    public GetItemByNameQueryHandler(IItemRepository itemRepository)
        => _itemRepository = itemRepository;

    public async Task<Item?> Handle(GetItemByNameQuery request, CancellationToken cancellationToken)
        => await _itemRepository.GetItemByNameAsync(request.Name, cancellationToken);
}