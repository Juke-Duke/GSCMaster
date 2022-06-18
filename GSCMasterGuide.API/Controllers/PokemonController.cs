using GSCMasterGuide.API.Queries.Pokemon;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace GSCMasterGuide.API.Controllers
{
    [ApiController]
    [Route("/pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PokemonController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAllPokemon(CancellationToken cancellationToken)
            => Ok(await _mediator.Send(new GetAllPokemonQuery(), cancellationToken));

        [HttpGet("{name}")]
        public async Task<IActionResult> GetPokemon(string name, CancellationToken cancellationToken)
        {
            var pokemon = await _mediator.Send(new GetPokemonQuery(name), cancellationToken);

            return pokemon is not null ? Ok(pokemon) : NotFound();
        }
    }
}