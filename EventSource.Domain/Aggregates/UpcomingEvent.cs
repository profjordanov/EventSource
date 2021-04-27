using System;
using EventSource.Domain.Events;

namespace EventSource.Domain.Aggregates
{
    public class UpcomingEvent : IAggregate
    {
        public Guid Id { get; set; }

        public string Data { get; set; }

        public bool Flag { get; set; }

        public UpcomingEventReceived ReceiveUpcomingEvent() => new UpcomingEventReceived
        {
            UpcomingEventId = Id,
            Data = Data
        };

        public void Apply(UpcomingEventReceived @event)
        {
            Data = @event.Data;
        }
    }
}