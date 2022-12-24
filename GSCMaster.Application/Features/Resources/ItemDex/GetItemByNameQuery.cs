using FluentValidation;
using GSCMaster.Application.Services.Repositories;
using GSCMaster.Core.ItemAggregate;
using MediatR;

namespace GSCMaster.Application.Features.Resources.ItemDex;
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