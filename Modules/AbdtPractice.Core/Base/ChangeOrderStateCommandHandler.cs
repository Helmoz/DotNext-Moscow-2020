using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Force.Extensions;
using Infrastructure.Cqrs;

namespace AbdtPractice.Core.Base
{
    public class ChangeOrderStateCommandHandler<TCommand, TFrom, TTo> :
        ICommandHandler<ChangeOrderStateContext<TCommand, TFrom>, Task<HandlerResult<OrderStatus>>>
        where TCommand : class, ICommand<Task<HandlerResult<OrderStatus>>>, IHasOrderId
        where TFrom : Order.OrderStateBase
        where TTo : Order.OrderStateBase
    {
        
        private IHandler<ChangeOrderStateContext<TCommand, TFrom>, Task<HandlerResult<TTo>>> Handler { get; set; }

        public ChangeOrderStateCommandHandler(
            IHandler<ChangeOrderStateContext<TCommand, TFrom>, 
            Task<HandlerResult<TTo>>> handler)
        {
            Handler = handler;
        }

        public Task<HandlerResult<OrderStatus>> Handle(ChangeOrderStateContext<TCommand, TFrom> input)
        {
            return Handler
                .Handle(input)
                .AwaitAndPipeTo(x => x.Match(y => new HandlerResult<OrderStatus>(y.EligibleStatus), y => y));
        }
    }
}