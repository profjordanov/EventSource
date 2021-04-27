using System;
using System.Threading.Tasks;
using EventSource.Domain.Events;

namespace EventSource.Persistence
{
    public interface IEventBus
    {
        Task Publish<TEvent>(Guid streamId, params TEvent[] events) where TEvent : IEvent;
    }
}