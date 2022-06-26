using Microsoft.AspNetCore.Mvc;
using GSCMasterGuide.Core.Queries.Items;
using MediatR;

namespace GSCMasterGuide.API.Controllers;
[ApiController]
[Route("/item")]
public class ItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllItems()
        => Ok(await _mediator.Send(new GetAllItemsQuery()));

    [HttpGet("{name}")]
    public async Task<IActionResult> GetItem(string name)
    {
        var item = await _mediator.Send(new GetItemQuery(name));

        return item is not null ? Ok(item) : NotFound();
    }
}
