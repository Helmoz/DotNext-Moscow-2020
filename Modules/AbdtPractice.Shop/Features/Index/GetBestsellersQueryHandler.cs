using System.Collections.Generic;
using System.Linq;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Infrastructure.Cqrs.Read;
using JetBrains.Annotations;
using Mapster;

namespace AbdtPractice.Shop.Features.Index
{
    [UsedImplicitly]
    public class
        GetBestsellersQueryHandler : GetIntEnumerableQueryHandlerBase<GetBestsellersQuery, Product, BestsellersListItem>
    {
        public GetBestsellersQueryHandler(IQueryable<Product> queryable) : base(queryable) { }
    }
}
