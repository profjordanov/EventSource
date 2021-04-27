using System;

namespace EventSource.Domain.Events
{
    public class FlagSetted : IEvent
    {
        public Guid UpcomingEventId { get; set; }

        public bool Flag { get; set; }
    }
}