using GSCMasterGuide.API.Queries.Pokemon;
using GSCMasterGuide.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace GSCMasterGuide.Identity.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PokemonController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Pokemon>>> GetAllPokemon()
            => Ok(await _mediator.Send(new GetAllPokemonQuery()));
    }
}