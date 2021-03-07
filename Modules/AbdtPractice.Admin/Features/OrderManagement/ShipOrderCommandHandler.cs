using System.Threading.Tasks;
using AbdtPractice.Core.Base;
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
            var result = input.Order.With<Order.Paid, Order.Shipped>(paidOrder => paidOrder.ToShipped());
            return result.EligibleStatus;
        }
    }
}
