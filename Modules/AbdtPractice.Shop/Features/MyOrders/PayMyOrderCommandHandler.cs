using System.Linq;
using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Ccc;
using Force.Cqrs;
using Infrastructure.Cqrs;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class PayMyOrderCommandHandler : ICommandHandler<PayMyOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        private readonly IQueryable<Order> _orders;
        private readonly IUnitOfWork _unitOfWork;

        public PayMyOrderCommandHandler(IQueryable<Order> orders, IUnitOfWork unitOfWork)
        {
            _orders = orders;
            _unitOfWork = unitOfWork;
        }
        public async Task<HandlerResult<OrderStatus>> Handle(PayMyOrderContext input)
        {
            await Task.Delay(1000);
            var result = input.Entity.BecomePaid();
            return new HandlerResult<OrderStatus>(result);
        }
    }
}
