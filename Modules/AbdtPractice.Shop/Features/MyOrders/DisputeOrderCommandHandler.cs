using System.Threading.Tasks;
using AbdtPractice.Core.Base;
using AbdtPractice.Core.Entities;
using Force.Ccc;
using Force.Cqrs;
using Infrastructure.Cqrs;
using Infrastructure.Workflow;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

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
