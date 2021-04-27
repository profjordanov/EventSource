using System.Linq;
using EventSource.Domain.Aggregates;
using EventSource.Domain.Events;
using EventSource.Domain.Views;
using EventSource.Persistence;
using Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventSource.Api.Configuration
{
    public static class DependenciesConfiguration
    {
        public static void EnsureEventStoreIsCreated(IConfiguration configuration)
        {
            DocumentStore.For(options =>
            {
                options.Connection(configuration.GetSection("EventStore")["ConnectionString"]);
                options.CreateDatabasesForTenants(c =>
                {
                    c.ForTenant()
                        .CheckAgainstPgDatabase()
                        .WithOwner("postgres")
                        .WithEncoding("UTF-8")
                        .ConnectionLimit(-1);
                });
            });
        }

        public static void AddMarten(this IServiceCollection services, IConfiguration configuration)
        {
            var documentStore = DocumentStore.For(options =>
            {
                var config = configuration.GetSection("EventStore");
                var connectionString = config.GetValue<string>("ConnectionString");
                var schemaName = config.GetValue<string>("Schema");

                options.Connection(connectionString);
                options.AutoCreateSchemaObjects = AutoCreate.All;
                options.Events.DatabaseSchemaName = schemaName;
                options.DatabaseSchemaName = schemaName;

                options.Events.InlineProjections.AggregateStreamsWith<UpcomingEvent>();
                options.Events.InlineProjections.Add(new UpcomingEventViewProjection());

                var events = typeof(UpcomingEventReceived)
                    .Assembly
                    .GetTypes()
                    .Where(t => typeof(IEvent).IsAssignableFrom(t))
                    .ToList();

                options.Events.AddEventTypes(events);
            });

            services.AddSingleton<IDocumentStore>(documentStore);

            services.AddScoped(sp => sp.GetService<IDocumentStore>()?.OpenSession());

            services.AddScoped<IEventBus, EventBus>();
        }
    }
}