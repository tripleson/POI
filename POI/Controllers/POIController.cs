using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Point.Command;
using Application.Point.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace POI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class POIController : ControllerBase
    {
        private readonly IMediator _mediator;

        public POIController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPointList([FromQuery] GetPointQuery getPointQuery)
        {
            return Ok(await _mediator.Send(getPointQuery));
        }

        [HttpGet]
        public async Task<IActionResult> GetPointByLoLa([FromQuery] GetPointByLoLa getPointByLoLa)
        {
            return Ok(await _mediator.Send(getPointByLoLa));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePoint([FromBody] CreatePointCommand createPointCommand)
        {
            await  _mediator.Send(createPointCommand);

            return Ok("DONEEEEEEEEEEE");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePoint([FromBody] UpdatePointCommand updatePointCommand)
        {
            await _mediator.Send(updatePointCommand);

            return Ok("DONEEEEEEEEE Updating");
        }
    }
}
