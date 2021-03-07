using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;

namespace AbdtPractice.Core.Base
{
    public class ChangeOrderStateContext<TCommand, TState> :
        OperationContextBase<TCommand>,
        IHasState<TState>,
        ICommand<Task<HandlerResult<OrderStatus>>>
        where TCommand : class, IHasOrderId
        where TState : Order.OrderStateBase
    {
        public ChangeOrderStateContext(TCommand request, Order order) : base(request)
        {
            Order = order;
        }

        [Required]
        public Order Order { get; }

        [Required]
        public TState State => Order.As<TState>();
    }
}