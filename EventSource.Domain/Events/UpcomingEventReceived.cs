using System;

namespace EventSource.Domain.Events
{
    public class UpcomingEventReceived : IEvent
    {
        public Guid UpcomingEventId { get; set; }

        public string Data { get; set; }
    }
}