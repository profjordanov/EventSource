using System;
using System.Threading.Tasks;
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

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var aggregate = new UpcomingEvent
            {
                Id = Guid.NewGuid(),
                Data = $"random-data-{Guid.NewGuid()}-{Guid.NewGuid()}"
            };

            await _eventBus.Publish(Guid.NewGuid(), aggregate.ReceiveUpcomingEvent());

            return Created(string.Empty, aggregate);
        }
    }
}
