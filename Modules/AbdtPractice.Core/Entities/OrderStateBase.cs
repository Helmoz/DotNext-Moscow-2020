using Infrastructure.Cqrs;
using Infrastructure.Ddd.Domain.State;
using Infrastructure.Workflow;

namespace AbdtPractice.Core.Entities
{
    public partial class Order
    {
        public abstract class OrderStateBase : SingleStateBase<Order, OrderStatus>
        {
            protected OrderStateBase(Order order) : base(order)
            {
            }
        }
    }
}