using CleanArchitecture.Application.Features.Streamer2.Commands.CreateStreamer;
using CleanArchitecture.Application.Features.Streamer2.Commands.UpdateStreamer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StreameController:ControllerBase
    {
        private IMediator _mediator;

        public StreameController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name ="CreateStreamer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateStreamer([FromBody] CreateStreamerCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut(Name ="UpdateStreamer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateStreamer([FromBody] UpdateStreamerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
