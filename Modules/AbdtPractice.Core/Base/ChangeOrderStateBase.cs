using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Force.Ddd;
using Infrastructure.Cqrs;

namespace AbdtPractice.Core.Base
{
    public abstract class ChangeOrderStateBase : IHasId<int>, ICommand<Task<HandlerResult<OrderStatus>>>
    {
        [Required]
        public int OrderId { get; set; }

        object IHasId.Id => Id;

        public int Id => OrderId;
    }
}