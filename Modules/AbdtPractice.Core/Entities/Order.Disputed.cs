namespace AbdtPractice.Core.Entities
{
    public partial class Order
    {
        public class Disputed : OrderStateBase
        { 
            public Disputed(Order entity) : base(entity) { }

            public override OrderStatus EligibleStatus => OrderStatus.Dispute;

            public Complete ToComplete()
            {
                return Entity.To<Complete>(OrderStatus.Complete);
            }
        }
    }
}