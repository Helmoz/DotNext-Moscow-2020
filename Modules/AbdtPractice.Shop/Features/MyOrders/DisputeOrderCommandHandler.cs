using System.Threading.Tasks;
using AbdtPractice.Core.Base;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Infrastructure.Cqrs;
using Infrastructure.Workflow;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class DisputeOrderCommandHandler : ICommandHandler<DisputeOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(DisputeOrderContext input)
        {
            await Task.Delay(1000);
            var result = input.Entity.With<Order.Shipped, Order.Disputed>(shippedOrder => shippedOrder.ToDisputed());
            return result.EligibleStatus;
        }
    }
}
