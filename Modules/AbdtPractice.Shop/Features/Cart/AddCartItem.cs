using Force.Cqrs;

namespace AbdtPractice.Shop.Features.Cart
{
    public class AddCartItem : ICommand
    {
        public AddCartItem(int productId)
        {
            ProductId = productId;
        }
        
        public int ProductId { get; set; }
    }
}
