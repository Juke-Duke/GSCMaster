using GSCMasterGuide.API.Queries.Items;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace GSCMasterGuide.API.Controllers
{
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
         => Ok(await _mediator.Send(new GetItemQuery(name)));   
    }
}
