using System.Linq;
using AbdtPractice.Core.Entities;
using Infrastructure.Cqrs.Read;

namespace AbdtPractice.Shop.Features.Index
{
    public class GetSaleQueryHandler : GetIntEnumerableQueryHandlerBase<GetSaleQuery, Product, SaleListItem>
    {
        public GetSaleQueryHandler(IQueryable<Product> queryable) : base(queryable) { }
    }
}
