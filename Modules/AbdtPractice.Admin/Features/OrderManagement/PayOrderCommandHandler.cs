using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Infrastructure.Cqrs;

namespace AbdtPractice.Admin.Features.OrderManagement
{
    public class PayOrderCommandHandler : ICommandHandler<PayOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(PayOrderContext input)
        {
            await Task.Delay(1000);
            var result = input.Order.With<Order.New, Order.Paid>(newOrder => newOrder.ToPaid());
            return result.EligibleStatus;
        }
    }
}
