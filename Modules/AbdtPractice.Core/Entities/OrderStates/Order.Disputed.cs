namespace AbdtPractice.Core.Entities
{
    public partial class Order
    {
        public class Disputed : OrderStateBase
        { 
            public Disputed(Order entity) : base(entity) { }

            public override OrderStatus OrderStatus => OrderStatus.Dispute;

            public Complete ToComplete()
            {
                Order.Status = OrderStatus.Complete;
                return (Complete)GetState(OrderStatus.Complete);
            }
        }
    }
}