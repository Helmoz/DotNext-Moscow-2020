using System.Linq;
using Force.Cqrs;

namespace AbdtPractice.Shop.Features.Catalog
{
    public class GetProductsQuery: FilterQuery<ProductListItem>
    {
        public int CategoryId { get; set; }
        public GetProductsQuery()
        {
            Order = "Id";
            CategoryId = 1;
        }

        public override IQueryable<ProductListItem> Filter(IQueryable<ProductListItem> queryable)
        {
            return base.Filter(queryable.Where(x => x.CategoryId == CategoryId));
        }

        public override IOrderedQueryable<ProductListItem> Sort(IQueryable<ProductListItem> queryable)
        {
            if (Order == "dateCreated")
            {
                return Asc ? queryable.OrderByDescending(x => x.Created) : queryable.OrderBy(x => x.Created);
            }
            return base.Sort(queryable);
        }
    }
}