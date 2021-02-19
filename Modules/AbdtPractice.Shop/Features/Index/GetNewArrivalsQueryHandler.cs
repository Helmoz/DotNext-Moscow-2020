using System.Linq;
using AbdtPractice.Core.Entities;
using Infrastructure.Cqrs.Read;
using JetBrains.Annotations;
using Mapster;

namespace AbdtPractice.Shop.Features.Index
{
    [UsedImplicitly]
    public class
        GetNewArrivalsQueryHandler : GetIntEnumerableQueryHandlerBase<GetNewArrivals, Product, NewArrivalsListItem>
    {
        public GetNewArrivalsQueryHandler(IQueryable<Product> queryable) : base(queryable) { }

        protected override IQueryable<NewArrivalsListItem> Map(IQueryable<Product> queryable, GetNewArrivals query)
        {
            return queryable
                .ProjectToType<NewArrivalsListItem>()
                .OrderByDescending(x => x.DateCreated)
                .Take(4);
        }
    }
}
