using System.Linq;
using AbdtPractice.Core.Entities;
using Infrastructure.Cqrs.Read;
using JetBrains.Annotations;

namespace AbdtPractice.Shop.Features.Index
{
    [UsedImplicitly]
    public class GetBestsellersQueryHandler : GetIntEnumerableQueryHandlerBase<GetBestsellersQuery, Product, BestsellersListItem>
    {
        public GetBestsellersQueryHandler(IQueryable<Product> queryable) : base(queryable) { }
    }
}
