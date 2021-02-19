using System.ComponentModel.DataAnnotations;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Infrastructure.OperationContext;

namespace AbdtPractice.Shop.Features.Cart
{
    public class AddCartItemContext: OperationContextBase<AddCartItem>, ICommand
    {
        public AddCartItemContext(AddCartItem request, Product product) : base(request)
        {
            Product = product;
        }

        [Required]
        public Product Product { get; }
    }
}