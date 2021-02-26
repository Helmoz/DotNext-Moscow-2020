namespace AbdtPractice.Core.Entities
{
    public partial class Order
    {
        public class Paid : OrderStateBase
        {
            public Paid(Order entity) : base(entity) { }

            public override OrderStatus OrderStatus => OrderStatus.Paid;

            public Shipped ToShipped()
            {
                Order.Status = OrderStatus.Shipped;
                return (Shipped)GetState(OrderStatus.Shipped);
            }

        }
    }
}