using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Ccc;
using Force.Cqrs;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class DisputeOrderContext : IntEntityOperationContextBase<DisputeOrder, Order>, 
        ICommand<Task<HandlerResult<OrderStatus>>>
    {
        public DisputeOrderContext(DisputeOrder request, IUnitOfWork unitOfWork) : base(request, unitOfWork) { }
    }
}