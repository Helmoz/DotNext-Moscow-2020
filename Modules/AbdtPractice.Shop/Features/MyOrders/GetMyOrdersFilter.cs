using System.Linq;
using AbdtPractice.Core.Entities;
using AbdtPractice.Identity.Services;
using Infrastructure.Ddd;
using JetBrains.Annotations;

namespace AbdtPractice.Shop.Features.MyOrders
{
    [UsedImplicitly]
    public class GetMyOrdersFilter : IFilter<Order, GetMyOrdersQuery>
    {
        private readonly IUserContext _userContext;

        public GetMyOrdersFilter(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public IQueryable<Order> Filter(IQueryable<Order> queryable, GetMyOrdersQuery predicate) =>
            _userContext.IsAuthenticated
                ? queryable.Where(Order.Specs.ByUserName(_userContext.User?.UserName!))
                : queryable.Where(x => false);
    }
}