using System;
using EventSource.Domain.Events;

namespace EventSource.Domain.Views
{
    public class UpcomingEventView
    {
        public Guid Id { get; set; }

        public string Data { get; set; }

        public bool Flag { get; set; }

        public void Apply(UpcomingEventReceived @event)
        {
            Id = @event.UpcomingEventId;
            Data = @event.Data;
        }

        public void Apply(FlagSetted @event)
        {
            Id = @event.UpcomingEventId;
            Flag = @event.Flag;
        }
    }
}