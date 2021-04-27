using System;
using EventSource.Domain.Events;
using Marten.Events.Projections;

namespace EventSource.Domain.Views
{
    public class UpcomingEventViewProjection : ViewProjection<UpcomingEventView, Guid>
    {
        public UpcomingEventViewProjection()
        {
            ProjectEvent<UpcomingEventReceived>(
                ev => ev.UpcomingEventId,
                (view, @event) => view.Apply(@event));

            ProjectEvent<FlagSetted>(
                ev => ev.UpcomingEventId,
                (view, @event) => view.Apply(@event));
        }
    }
}