using System;
using EventSource.Domain.Events;

namespace EventSource.Domain.Aggregates
{
    public class Order : IAggregate
    {
        public Order()
        {
        }

        public Order(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public bool IsCancelled { get; set; }
        public decimal ItemValue { get; set; }

        public OrderRegistered RegisterOrder() => new OrderRegistered
        {
            Id = Id,
            CustomerName = CustomerName,
            OrderNumber = OrderNumber,
            ItemValue = ItemValue
        };

        public void Apply(OrderRegistered @event)
        {
            Id = @event.Id;
            CustomerName = @event.CustomerName;
            ItemValue = @event.ItemValue;
            OrderNumber = @event.OrderNumber;
        }

        public OrderCancelled CancelOrder() => new OrderCancelled
        {
            IsCancelled = true
        };

        public void Apply(OrderCancelled @event)
        {
            IsCancelled = @event.IsCancelled;
        }
    }
}