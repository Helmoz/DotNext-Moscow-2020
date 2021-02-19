using System.Linq;
using AbdtPractice.Core.Entities;
using Infrastructure.Cqrs.Read;

namespace AbdtPractice.Shop.Features.Catalog
{
    public class GetCategoriesQueryHandler : GetIntEnumerableQueryHandlerBase<GetCategoriesQuery, Category, CategoryListItem>
    {
        public GetCategoriesQueryHandler(IQueryable<Category> queryable) : base(queryable)
        {
        }
    }
}