using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Infrastructure.Cqrs;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class PayMyOrderCommandHandler : ICommandHandler<PayMyOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(PayMyOrderContext input)
        {
            await Task.Delay(1000);
            var result = new Order.New(input.Entity).ToPaid();
            return new HandlerResult<OrderStatus>(result.OrderStatus);
        }
    }
}
