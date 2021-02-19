using System.Linq;
using AbdtPractice.Core.Entities;
using AbdtPractice.Identity.Entities;

namespace AbdtPractice.Core.Services
{
    public static class CartExtensions
    {
        public static CartDto ToDto(this Cart cart)
        {
            return new()
            {
                Id = cart.Id,
                CartItems = cart.CartItems.ToList()
            };
        }

        public static Cart FromDto(this CartDto dto, User user)
        {
            if (dto == null) return null;
            return new Cart(dto.Id, dto.CartItems, user);
        }
    }
}