using System.Linq;
using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Ccc;
using Force.Cqrs;
using Infrastructure.Cqrs;

namespace AbdtPractice.Admin.Features.OrderManagement
{
    public class PayOrderCommandHandler :
        ICommandHandler<PayOrder, Task<HandlerResult<OrderStatus>>>
    {
        private readonly IQueryable<Order> _orders; 
        private readonly IUnitOfWork _unitOfWork;
        public PayOrderCommandHandler(
            IQueryable<Order> orders,
            IUnitOfWork unitOfWork)
        {
            _orders = orders;
            _unitOfWork = unitOfWork;
        }
        public async Task<HandlerResult<OrderStatus>> Handle(PayOrder input)
        {
            var order = _orders.First(x => x.Id == input.OrderId);
            await Task.Delay(1000);
            var result = order.BecomePaid();
            _unitOfWork.Commit();
            return new HandlerResult<OrderStatus>(result);
        }
    }
}
