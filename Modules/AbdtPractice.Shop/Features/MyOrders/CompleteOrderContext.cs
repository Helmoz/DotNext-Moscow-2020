using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Ccc;
using Force.Cqrs;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class CompleteOrderContext : IntEntityOperationContextBase<CompleteOrder, Order>,
        ICommand<Task<HandlerResult<OrderStatus>>>
    {
        public CompleteOrderContext(CompleteOrder request, IUnitOfWork unitOfWork) : base(request, unitOfWork) { }
    }
}