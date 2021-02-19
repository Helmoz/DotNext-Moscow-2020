using System.Linq;
using AbdtPractice.Core.Entities;
using Infrastructure.Cqrs.Read;
using JetBrains.Annotations;

namespace AbdtPractice.Admin.Features.OrderManagement
{
    [UsedImplicitly]
    public class GetAllOrdersHandler : GetIntEnumerableQueryHandlerBase<GetAllOrders, Order, OrderListItem>
    {
        public GetAllOrdersHandler(IQueryable<Order> queryable) : base(queryable)
        {
        }
    }
}
