using System.Net.Http;
using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Ccc;
using Force.Cqrs;
using Infrastructure.Cqrs;

namespace AbdtPractice.Core.Base
{
    public abstract class ChangeOrderStateHandlerBase<TCommand, TFrom, TTo> :
        IHandler<ChangeOrderStateContext<TCommand, TFrom>, Task<HandlerResult<TTo>>>
        where TCommand : class, IHasOrderId
        where TFrom : Order.OrderStateBase
        where TTo : Order.OrderStateBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeOrderStateHandlerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HandlerResult<TTo>> Handle(ChangeOrderStateContext<TCommand, TFrom> input)
        {
            using var tr = _unitOfWork.BeginTransaction();
            try
            {
                //Other services(http)
                var result = ChangeState(input);
                _unitOfWork.Commit();
                await tr.CommitAsync();
                return result;
            }
            catch (HttpRequestException e)
            {
                await tr.RollbackAsync();
                return e;
            }
        }

        protected abstract TTo ChangeState(ChangeOrderStateContext<TCommand, TFrom> input);
    }
}