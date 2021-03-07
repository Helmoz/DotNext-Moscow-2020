namespace AbdtPractice.Core.Entities
{
    public partial class Order
    {
        public class Paid : OrderStateBase
        {
            public Paid(Order entity) : base(entity) { }

            public override OrderStatus EligibleStatus => OrderStatus.Paid;

            public Shipped ToShipped()
            {
                return Entity.To<Shipped>(OrderStatus.Shipped);
            }
        }
    }
}