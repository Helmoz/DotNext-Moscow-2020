using System.Linq;
using AbdtPractice.Core.Entities;
using AbdtPractice.Core.Services;
using Force.Cqrs;

namespace AbdtPractice.Shop.Features.Cart
{
    public class AddCartItemCommandHandler : ICommandHandler<AddCartItemContext>
    {
        private readonly ICartStorage _cartStorage;
        private readonly IQueryable<Product> _products;

        public AddCartItemCommandHandler(ICartStorage cartStorage,
            IQueryable<Product> products)
        {
            _cartStorage = cartStorage;
            _products = products;
        }

        public void Handle(AddCartItemContext input)
        {
            _cartStorage.Cart.AddProduct(input.Product);
            _cartStorage.SaveChanges();
        }
    }
}
