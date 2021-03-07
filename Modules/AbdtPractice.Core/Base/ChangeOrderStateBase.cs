using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Force.Ddd;
using Infrastructure.Cqrs;

namespace AbdtPractice.Core.Base
{
    public abstract class ChangeOrderStateBase : 
        HasIdBase, 
        IHasOrderId, 
        ICommand<Task<HandlerResult<OrderStatus>>>
    {
        [Required]
        public int OrderId { get; set; }
    }
}