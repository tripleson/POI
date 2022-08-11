using Application.SuperHero.Command.Create;
using Application.SuperHero.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace POI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSuperHeroCommand createSuperHeroCommand)
        {
            await _mediator.Send(createSuperHeroCommand);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetSuperHeroesQuery()));
        }
    }
}
