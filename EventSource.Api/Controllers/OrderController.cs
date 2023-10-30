using System;
using EventSource.Api.Commands;
using EventSource.Domain.Aggregates;
using EventSource.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventSource.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IEventBus _eventBus;

    public OrderController(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Receive([FromBody] RegisterOrder command)
    {
        var aggregate = new Order
        {
            Id = Guid.NewGuid(),
            CustomerName = nameof(Order.CustomerName),
            OrderNumber = new Random().Next(),
            ItemValue = 25m
        };

        await _eventBus.Publish(aggregate.Id, aggregate.RegisterOrder());

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