namespace AbdtPractice.Core.Entities
{
    public partial class Order
    {
        public class Complete : OrderStateBase
        {
            public Complete(Order entity) : base(entity) { }

            public override OrderStatus OrderStatus => OrderStatus.Complete;
        }
    }
}