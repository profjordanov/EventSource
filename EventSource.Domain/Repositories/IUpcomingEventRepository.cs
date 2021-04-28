using System.Collections.Generic;
using System.Threading.Tasks;
using EventSource.Domain.Events;
using EventSource.Domain.Views;
using IEvent = Marten.Events.IEvent;

namespace EventSource.Domain.Repositories
{
    public interface IUpcomingEventRepository
    {
        Task<IReadOnlyList<UpcomingEventView>> ViewListByDataAsync(string data);

        Task<IReadOnlyList<IEvent>> EventsListAsync();

        Task<IReadOnlyList<UpcomingEventReceived>> UpcomingEventReceivedAsync();
    }
}