using Microsoft.AspNetCore.Mvc;
using MediatR;
using GSCMasterGuide.Shared.Requests.Authentication;
using GSCMasterGuide.Shared.Responses.Authentication;
using GSCMasterGuide.API.Commands.Authentication;

namespace GSCMasterGuide.Infrastructure.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new RegisterCommand(request.Email, request.Username, request.Password, request.ConfirmPassword), cancellationToken);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new LoginCommand(request.Username, request.Password), cancellationToken);

            return Ok(response);
        }
    }
}