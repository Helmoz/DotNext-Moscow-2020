using AbdtPractice.Core.Base;
using AbdtPractice.Core.Entities;
using Force.Ccc;
using JetBrains.Annotations;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class PayOrderCommandHandler : ChangeOrderStateHandlerBase<PayOrder, Order.New, Order.Paid>
    {
        public PayOrderCommandHandler([NotNull] IUnitOfWork unitOfWork) : base(unitOfWork) { }

        protected override Order.Paid ChangeState(ChangeOrderStateContext<PayOrder, Order.New> input)
        {
            return input.State.ToPaid();
        }
    }
}
