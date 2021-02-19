using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Force.Ddd;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;

namespace AbdtPractice.Admin.Features.OrderManagement
{
    public class BaseOrderContext<T> : ByIntIdOperationContextBase<T>, ICommand<Task<HandlerResult<OrderStatus>>>
        where T : class, IHasId<int>
    {
        [Required] 
        public Order Order { get; }

        public BaseOrderContext(T request, Order order) : base(request)
        {
            Order = order;
        }
    }
}