using System.Collections.Generic;
using Force.Cqrs;

namespace AbdtPractice.Shop.Features.Catalog
{
    public class GetCategoriesQuery : IQuery<IEnumerable<CategoryListItem>>
    {
    }
}
