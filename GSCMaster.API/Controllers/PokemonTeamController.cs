using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace GSCMaster.Infrastructure.Controllers
{
    [ApiController]
    [Route("/teams")]
    public class PokemonTeamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PokemonTeamController(IMediator mediator)
            => _mediator = mediator;
    }
}