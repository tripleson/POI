using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Point.Command;
using Application.Point.Query;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public POIController(IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPointList([FromQuery] GetPointQuery getPointQuery)
        {
            var data = await _mediator.Send(getPointQuery);
            var dto = _mapper.Map<List<PointDTO>>(data);
            
            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetPointByLoLa([FromQuery] GetPointByLoLa getPointByLoLa)
        {
            var point = await _mediator.Send(getPointByLoLa);
            var dto = _mapper.Map<PointDTO>(point);
            
            return Ok(dto);
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

        [HttpDelete]
        public async Task<IActionResult> DeletePoint([FromBody] DeletePointCommand deletePointCommand)
        {
            await _mediator.Send(deletePointCommand);

            return Ok("DELETEEEEE DONEEEEEEEEEE");
        }
    }
}
