namespace AbdtPractice.Core.Entities
{
    public partial class Order
    {
        public class Shipped : OrderStateBase
        {
            public Shipped(Order entity) : base(entity) { }

            public override OrderStatus EligibleStatus => OrderStatus.Shipped;

            public Disputed ToDisputed()
            {
                return Entity.To<Disputed>(OrderStatus.Dispute);
            }

            public Complete ToComplete()
            {
                return Entity.To<Complete>(OrderStatus.Complete);
            }
        }
    }
}