using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AbdtPractice.Identity.Entities;
using Force.Extensions;
using Infrastructure.Ddd;

namespace AbdtPractice.Core.Entities
{
    public class Order : IntEntityBase
    {
        public static readonly OrderSpecs Specs = new();

        private readonly List<OrderItem> _orderItems = new();

        protected Order()
        {
        }

        public Order(Cart cart)
        {
            User = cart.User ?? throw new InvalidOperationException("User must be authenticated");

            _orderItems = cart
                .CartItems
                .Select(x => new OrderItem(this, x))
                .ToList();

            Total = _orderItems.Select(x => x.Price).Sum();
            Status = OrderStatus.New;
            this.EnsureInvariant();
        }

        [Required] public virtual User User { get; protected set; }

        public DateTime Created { get; protected set; } = DateTime.UtcNow;

        public DateTime Updated { get; protected set; }

        public virtual IEnumerable<OrderItem> OrderItems => _orderItems;

        public double Total { get; protected set; }

        public Guid? TrackingCode { get; protected set; }

        public OrderStatus Status { get; protected set; }

        public OrderStatus BecomePaid()
        {
            Status = OrderStatus.Paid;
            return Status;
        }

        public OrderStatus BecomeShipped()
        {
            Status = OrderStatus.Shipped;
            return Status;
        }

        public OrderStatus BecomeDispute()
        {
            Status = OrderStatus.Dispute;
            return Status;
        }

        public OrderStatus BecomeComplete()
        {
            Status = OrderStatus.Complete;
            return Status;
        }
    }
}