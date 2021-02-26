using AbdtPractice.Core.Services;
using Force.Cqrs;

namespace AbdtPractice.Shop.Features.Cart
{
    public class RemoveCartItemCommandHandler : ICommandHandler<RemoveCartItemContext, bool>
    {
        private readonly ICartStorage _cartStorage;

        public RemoveCartItemCommandHandler(ICartStorage cartStorage)
        {
            _cartStorage = cartStorage;
        }
        public bool Handle(RemoveCartItemContext input)
        {
            var res = _cartStorage.Cart.TryRemoveProduct(input.Product.Id);
            _cartStorage.SaveChanges();
            return res;
        }
    }
}
