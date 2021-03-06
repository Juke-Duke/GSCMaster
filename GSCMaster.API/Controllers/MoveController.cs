using Microsoft.AspNetCore.Mvc;
using GSCMaster.Core.Queries.Moves;
using MediatR;

namespace GSCMaster.API.Controllers;
[ApiController]
[Route("/move")]
public class MoveController : ControllerBase
{
    private readonly IMediator _mediator;

    public MoveController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMoves()
        => Ok(await _mediator.Send(new GetAllMovesQuery()));

    [HttpGet("{name}")]
    public async Task<IActionResult> GetMove(string name)
    {
        var move = await _mediator.Send(new GetMoveQuery(name));

        return move is not null ? Ok(move) : NotFound();
    }
}