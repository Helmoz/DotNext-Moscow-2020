using System.Linq;
using AbdtPractice.Core.Entities;
using Infrastructure.Cqrs.Read;
using JetBrains.Annotations;

namespace AbdtPractice.Shop.Features.Catalog
{
    [UsedImplicitly]
    public class GetProductsQueryHandler : GetIntEnumerableQueryHandlerBase<GetProductsQuery, Product, ProductListItem>
    {
        public GetProductsQueryHandler(IQueryable<Product> queryable) : base(queryable) { }
    }
}
