using Force.Cqrs;

namespace AbdtPractice.Shop.Features.Cart
{
    public class RemoveCartItem : ICommand<bool>
    {
        public RemoveCartItem(int productId)
        {
            ProductId = productId;
        }
        
        public int ProductId { get; set; }
    }
}
