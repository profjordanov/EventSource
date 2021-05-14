using System.Threading.Tasks;

namespace EventSource.Api.Configuration
{
    public interface IDatabaseSeeder
    {
        Task SeedDatabaseAsync();
    }
}