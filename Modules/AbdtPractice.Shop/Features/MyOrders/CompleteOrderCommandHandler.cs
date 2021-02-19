using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Infrastructure.Cqrs;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class CompleteOrderCommandHandler : ICommandHandler<CompleteOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(CompleteOrderContext input)
        {
            await Task.Delay(1000);
            var result = input.Entity.BecomeComplete();
            return new HandlerResult<OrderStatus>(result);
        }
    }
}
