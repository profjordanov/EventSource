using System;
using EventSource.Domain.Events;

namespace EventSource.Domain.Views
{
    public class UpcomingEventView
    {
        public Guid Id { get; set; }

        public string Data { get; set; }

        public void Apply(UpcomingEventReceived @event)
        {
            Id = @event.UpcomingEventId;
            Data = @event.Data;
        }
    }
}