using System.Linq;
using AbdtPractice.Core.Entities;
using Infrastructure.Cqrs.Read;
using JetBrains.Annotations;

namespace AbdtPractice.Shop.Features.MyOrders
{
    [UsedImplicitly]
    public class GetMyOrdersQueryHandler : GetIntEnumerableQueryHandlerBase<GetMyOrdersQuery, Order, MyOrdersListItem>
    {
        public GetMyOrdersQueryHandler(IQueryable<Order> queryable) : base(queryable) { }
    }
}
