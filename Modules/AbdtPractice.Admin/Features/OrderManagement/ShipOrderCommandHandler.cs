using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Infrastructure.Cqrs;

namespace AbdtPractice.Admin.Features.OrderManagement
{
    public class ShipOrderCommandHandler : ICommandHandler<ShipOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(ShipOrderContext input)
        {
            await Task.Delay(1000);
            var result = new Order.Paid(input.Order).ToShipped();
            return new HandlerResult<OrderStatus>(result.OrderStatus);
        }
    }
}
