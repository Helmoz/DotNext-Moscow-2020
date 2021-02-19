using AbdtPractice.Core.Services;
using Force.Cqrs;

namespace AbdtPractice.Shop.Features.Cart
{
    public class RemoveCartItemCommandHandler : ICommandHandler<RemoveCartItem, bool>
    {
        private readonly ICartStorage _cartStorage;

        public RemoveCartItemCommandHandler(ICartStorage cartStorage)
        {
            _cartStorage = cartStorage;
        }
        public bool Handle(RemoveCartItem input)
        {
            var res = _cartStorage.Cart.TryRemoveProduct(input.ProductId);
            _cartStorage.SaveChanges();
            return res;
        }
    }
}
