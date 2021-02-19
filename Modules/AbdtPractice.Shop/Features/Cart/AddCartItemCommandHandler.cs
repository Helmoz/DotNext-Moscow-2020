using System.Linq;
using AbdtPractice.Core.Entities;
using AbdtPractice.Core.Services;
using Force.Cqrs;

namespace AbdtPractice.Shop.Features.Cart
{
    public class AddCartItemCommandHandler : ICommandHandler<AddCartItem>
    {
        private readonly ICartStorage _cartStorage;
        private readonly IQueryable<Product> _products;

        public AddCartItemCommandHandler(ICartStorage cartStorage,
            IQueryable<Product> products)
        {
            _cartStorage = cartStorage;
            _products = products;
        }

        public void Handle(AddCartItem input)
        {
            var product = _products.First(x => x.Id == input.ProductId);
            _cartStorage.Cart.AddProduct(product);
            _cartStorage.SaveChanges();
        }
    }
}
