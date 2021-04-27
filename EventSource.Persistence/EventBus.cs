using System;
using System.Threading.Tasks;
using EventSource.Domain.Events;
using Marten;

namespace EventSource.Persistence
{
    public class EventBus : IEventBus
    {
        private readonly IDocumentSession _session;

        public EventBus(IDocumentSession session)
        {
            _session = session;
        }

        public Task Publish<TEvent>(Guid streamId, params TEvent[] events) where TEvent : IEvent
        {
            foreach (var @event in events)
            {
                _session.Events.Append(streamId, @event);
            }

            return _session.SaveChangesAsync();
        }
    }
}