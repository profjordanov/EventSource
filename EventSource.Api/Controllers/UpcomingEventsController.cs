using System.Threading.Tasks;
using EventSource.Api.Commands;
using EventSource.Domain.Aggregates;
using EventSource.Domain.Repositories;
using EventSource.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace EventSource.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpcomingEventsController : ControllerBase
    {
        private readonly IEventBus _eventBus;
        private readonly IUpcomingEventRepository _repository;

        public UpcomingEventsController(IEventBus eventBus, IUpcomingEventRepository repository)
        {
            _eventBus = eventBus;
            _repository = repository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            // Query Handler
            var result = await _repository.EventsListAsync();
            return Ok(result);
        }

        [HttpGet("received")]
        public async Task<IActionResult> Received()
        {
            // Query Handler
            var result = await _repository.UpcomingEventReceivedAsync();
            return Ok(result);
        }

        [HttpGet("views")] 
        public async Task<IActionResult> GetViewsByData([FromQuery] string data)
        {
            // Query Handler
            var result = await _repository.ViewListByDataAsync(data);
            return Ok(result);
        }

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
        public async Task<IActionResult> Flag([FromBody] FlagCommand command)
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
