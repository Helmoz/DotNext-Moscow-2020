using System.ComponentModel.DataAnnotations;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Infrastructure.OperationContext;

namespace AbdtPractice.Shop.Features.Cart
{
    public class RemoveCartItemContext: OperationContextBase<RemoveCartItem>, ICommand<bool>
    {
        public RemoveCartItemContext(RemoveCartItem request, Product product) : base(request)
        {
            Product = product;
        }

        [Required]
        public Product Product { get; }
    }
}