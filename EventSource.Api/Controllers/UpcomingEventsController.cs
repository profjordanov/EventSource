using System.Threading.Tasks;
using EventSource.Api.Commands;
using EventSource.Domain.Aggregates;
using EventSource.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace EventSource.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpcomingEventsController : ControllerBase
    {
        private readonly IEventBus _eventBus;

        public UpcomingEventsController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        [HttpGet] 
        public IActionResult Index() => Ok("Server up and running!");

        [HttpPost("receive")]
        public async Task<IActionResult> Receive([FromBody] ReceiveCommand command)
        {
            // Command Handler
            var aggregate = new UpcomingEvent
            {
                Id = command.Identifier,
                Data = command.Data
            };

            await _eventBus.Publish(aggregate.Id, aggregate.ReceiveUpcomingEvent());

            return Created(string.Empty, aggregate);
        }

        [HttpPost("flag")]
        public async Task<IActionResult> Receive([FromBody] FlagCommand command)
        {
            // Command Handler
            var aggregate = new UpcomingEvent
            {
                Id = command.Identifier,
                Flag = command.Flag
            };

            await _eventBus.Publish(aggregate.Id, aggregate.SetFlag());

            return Ok(aggregate);
        }
    }
}
