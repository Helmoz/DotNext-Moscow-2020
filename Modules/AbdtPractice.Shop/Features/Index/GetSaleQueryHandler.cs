using System.Collections.Generic;
using System.Linq;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Infrastructure.Cqrs.Read;
using Mapster;

namespace AbdtPractice.Shop.Features.Index
{
    public class GetSaleQueryHandler : GetIntEnumerableQueryHandlerBase<GetSaleQuery, Product, SaleListItem>
    {
        public GetSaleQueryHandler(IQueryable<Product> queryable) : base(queryable) { }
    }
}
