namespace AbdtPractice.Core.Entities
{
    public partial class Order
    {
        public class New : OrderStateBase
        {
            public New(Order entity) : base(entity) { }

            public override OrderStatus EligibleStatus => OrderStatus.New;

            public Paid ToPaid()
            {
                return Entity.To<Paid>(OrderStatus.Paid);
            }
        }
    }
}