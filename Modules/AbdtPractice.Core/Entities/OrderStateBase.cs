namespace AbdtPractice.Core.Entities
{
    public partial class Order
    {
        public abstract class OrderStateBase
        {
            protected OrderStateBase(Order order)
            {
                Order = order;
            }

            protected Order Order { get; set; }

            public virtual OrderStatus OrderStatus { get; set; }

            protected OrderStateBase GetState(OrderStatus status)
            {
                return status switch
                {
                    OrderStatus.New => new New(Order),
                    OrderStatus.Paid => new Paid(Order),
                    OrderStatus.Shipped => new Shipped(Order),
                    OrderStatus.Dispute => new Disputed(Order),
                    OrderStatus.Complete => new Complete(Order)
                };
            }
        }
    }
}