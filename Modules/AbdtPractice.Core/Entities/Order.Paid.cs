using System;

namespace AbdtPractice.Core.Entities
{
    public partial class Order
    {
        public class Paid : OrderStateBase
        {
            public Paid(Order entity) : base(entity) { }

            public override OrderStatus EligibleStatus => OrderStatus.Paid;

            public Shipped ToShipped(Guid trackingCode)
            {
                Entity.TrackingCode = trackingCode;
                return Entity.To<Shipped>(OrderStatus.Shipped);
            }
        }
    }
}