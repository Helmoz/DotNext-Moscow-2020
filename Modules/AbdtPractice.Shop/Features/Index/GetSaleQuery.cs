using System.Linq;
using Force.Cqrs;

namespace AbdtPractice.Shop.Features.Index
{
    public class GetSaleQuery : FilterQuery<SaleListItem>
    {
        public override IOrderedQueryable<SaleListItem> Sort(IQueryable<SaleListItem> queryable)
        {
            if (Order == "dateCreated")
            {
                return Asc ? queryable.OrderByDescending(x => x.DateCreated) : queryable.OrderBy(x => x.DateCreated);
            }
            return base.Sort(queryable);
        }
    }
}
