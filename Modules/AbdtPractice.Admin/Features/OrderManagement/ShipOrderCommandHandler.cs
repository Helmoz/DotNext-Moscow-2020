using System;
using AbdtPractice.Core.Base;
using AbdtPractice.Core.Entities;
using Force.Ccc;

namespace AbdtPractice.Admin.Features.OrderManagement
{
    public class ShipOrderCommandHandler : ChangeOrderStateHandlerBase<ShipOrder, Order.Paid, Order.Shipped>
    {
        public ShipOrderCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        protected override Order.Shipped ChangeState(ChangeOrderStateContext<ShipOrder, Order.Paid> input)
        {
            return input.State.ToShipped(Guid.NewGuid());
        }
    }
}
