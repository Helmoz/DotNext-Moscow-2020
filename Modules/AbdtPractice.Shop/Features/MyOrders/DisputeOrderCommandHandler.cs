using AbdtPractice.Core.Base;
using AbdtPractice.Core.Entities;
using Force.Ccc;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class DisputeOrderCommandHandler : ChangeOrderStateHandlerBase<DisputeOrder, Order.Shipped, Order.Disputed>
    {
        public DisputeOrderCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        protected override Order.Disputed ChangeState(ChangeOrderStateContext<DisputeOrder, Order.Shipped> input)
        {
            return input.State.ToDisputed(input.Request.Complaint);
        }
    }
}
