using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Infrastructure.Cqrs;
using Infrastructure.Workflow;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class PayMyOrderCommandHandler : ICommandHandler<PayMyOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(PayMyOrderContext input)
        {
            await Task.Delay(1000);
            var result = input.Entity.With((Order.New newOrder) => newOrder.ToPaid());
            return result.EligibleStatus;
        }
    }
}
