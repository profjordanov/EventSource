using System;

namespace EventSource.Domain.Events
{
    public class OrderRegistered : IEvent
    {
        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal ItemValue { get; set; }
    }
}