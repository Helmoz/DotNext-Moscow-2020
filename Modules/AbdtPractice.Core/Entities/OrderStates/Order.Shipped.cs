namespace AbdtPractice.Core.Entities
{
    public partial class Order
    {
        public class Shipped : OrderStateBase
        {
            public Shipped(Order entity) : base(entity) { }

            public override OrderStatus OrderStatus => OrderStatus.Shipped;

            public Disputed ToDisputed()
            {
                Order.Status = OrderStatus.Dispute;
                return (Disputed)GetState(OrderStatus.Dispute);
            }

            public Complete ToComplete()
            {
                Order.Status = OrderStatus.Complete;
                return (Complete)GetState(OrderStatus.Complete);
            }
        }
    }
}