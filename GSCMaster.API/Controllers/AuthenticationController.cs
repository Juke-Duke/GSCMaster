// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using GSCMaster.Shared.Requests.Authentication;
// using GSCMaster.Core.Commands.Authentication;

// namespace GSCMaster.API.Controllers;
// [ApiController]
// [Route("/auth")]
// public class AuthenticationController : ControllerBase
// {
//     private readonly IMediator _mediator;

//     public AuthenticationController(IMediator mediator, IConfiguration config)
//     {
//         _mediator = mediator;
//     }

//     [HttpPost("register")]
//     public async Task<ActionResult<bool>> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
//     {
//         var result = await _mediator.Send(new RegisterCommand(request.Email, request.Username, request.Password, request.ConfirmPassword), cancellationToken);
//         return Ok(result);
//     }
// }