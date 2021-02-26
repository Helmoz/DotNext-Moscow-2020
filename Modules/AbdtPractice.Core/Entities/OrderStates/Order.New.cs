namespace AbdtPractice.Core.Entities
{
    public partial class Order
    {
        public class New : OrderStateBase
        {
            public New(Order entity) : base(entity) { }

            public override OrderStatus OrderStatus => OrderStatus.New;

            public Paid ToPaid()
            {
                Order.Status = OrderStatus.Paid;
                return (Paid)GetState(OrderStatus.Paid);
            }
        }
    }
}