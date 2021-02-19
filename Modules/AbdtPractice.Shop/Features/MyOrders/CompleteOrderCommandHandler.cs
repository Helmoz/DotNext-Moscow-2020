using System.Linq;
using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Infrastructure.Cqrs;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class CompleteOrderCommandHandler :
        ICommandHandler<CompleteOrder, Task<HandlerResult<OrderStatus>>>
    {
        private readonly IQueryable<Order> _orders;
        public CompleteOrderCommandHandler(IQueryable<Order> orders)
        {
            _orders = orders;
        }
        public async Task<HandlerResult<OrderStatus>> Handle(CompleteOrder input)
        {
            var order = _orders.First(x => x.Id == input.OrderId);
            await Task.Delay(1000);
            var result = order.BecomeComplete();
            return new HandlerResult<OrderStatus>(result);
        }
    }
}
