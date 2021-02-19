using System.Linq;
using AbdtPractice.Core.Entities;
using Infrastructure.Ddd;
using JetBrains.Annotations;

namespace AbdtPractice.Shop.Features.Index
{
    [UsedImplicitly]
    public class GetSaleFilter : IFilter<Product, GetSaleQuery>
    {
        public IQueryable<Product> Filter(IQueryable<Product> queryable, GetSaleQuery predicate)
        {
            return queryable.Where(x => x.DiscountPercent > 0);
        }
    }
}