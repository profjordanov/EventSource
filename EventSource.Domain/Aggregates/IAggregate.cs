using System;

namespace EventSource.Domain.Aggregates
{
    public interface IAggregate
    {
        Guid Id { get; set; }
    }
}