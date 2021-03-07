using AbdtPractice.Core.Base;
using AbdtPractice.Core.Entities;
using Force.Ccc;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class CompleteOrderCommandHandler : ChangeOrderStateHandlerBase<CompleteOrder, Order.Shipped, Order.Complete>
    {
        public CompleteOrderCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        protected override Order.Complete ChangeState(ChangeOrderStateContext<CompleteOrder, Order.Shipped> input)
        {
            return input.State.ToComplete();
        }
    }
}
