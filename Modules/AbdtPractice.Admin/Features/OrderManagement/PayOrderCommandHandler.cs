using System.Linq;
using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Ccc;
using Force.Cqrs;
using Infrastructure.Cqrs;

namespace AbdtPractice.Admin.Features.OrderManagement
{
    public class PayOrderCommandHandler : ICommandHandler<PayOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(PayOrderContext input)
        {
            await Task.Delay(1000);
            var result = new Order.New(input.Order).ToPaid();
            return new HandlerResult<OrderStatus>(result.OrderStatus);
        }
    }
}
