using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventSource.Domain.Events;
using EventSource.Domain.Repositories;
using EventSource.Domain.Views;
using Marten;

namespace EventSource.Persistence
{
    public class UpcomingEventRepository : IUpcomingEventRepository
    {
        private readonly IDocumentSession _session;

        public UpcomingEventRepository(IDocumentSession session)
        {
            _session = session;
        }

        public Task<IReadOnlyList<UpcomingEventView>> ViewListByDataAsync(string data) =>
            _session
                .Query<UpcomingEventView>()
                .Where(view => view.Data == data)
                .ToListAsync();

        public Task<IReadOnlyList<Marten.Events.IEvent>> EventsListAsync() =>
            _session
                .Events
                .QueryAllRawEvents()
                .ToListAsync();

        public Task<IReadOnlyList<UpcomingEventReceived>> UpcomingEventReceivedAsync() =>
            _session
                .Events
                .QueryRawEventDataOnly<UpcomingEventReceived>()
                .ToListAsync();
    }
}