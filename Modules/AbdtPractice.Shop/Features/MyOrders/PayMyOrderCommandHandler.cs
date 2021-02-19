using System.Linq;
using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Ccc;
using Force.Cqrs;
using Infrastructure.Cqrs;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class PayMyOrderCommandHandler :
        ICommandHandler<PayMyOrder, Task<HandlerResult<OrderStatus>>>
    {
        private readonly IQueryable<Order> _orders;
        private readonly IUnitOfWork _unitOfWork;

        public PayMyOrderCommandHandler(IQueryable<Order> orders, IUnitOfWork unitOfWork)
        {
            _orders = orders;
            _unitOfWork = unitOfWork;
        }
        public async Task<HandlerResult<OrderStatus>> Handle(PayMyOrder input)
        {
            await Task.Delay(1000);
            var order = _orders.First(x => x.Id == input.OrderId);
            var result = order.BecomePaid();
            _unitOfWork.Commit();
            return new HandlerResult<OrderStatus>(result);
        }
    }
}
