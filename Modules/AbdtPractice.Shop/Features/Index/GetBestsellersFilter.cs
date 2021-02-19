using System.Linq;
using AbdtPractice.Core.Entities;
using Infrastructure.Ddd;
using JetBrains.Annotations;

namespace AbdtPractice.Shop.Features.Index
{
    [UsedImplicitly]
    public class GetBestsellersFilter : IFilter<Product, GetBestsellersQuery>
    {
        public IQueryable<Product> Filter(IQueryable<Product> queryable, GetBestsellersQuery predicate)
        {
            return queryable.Where(Product.Specs.IsBestseller);
        }
    }
}