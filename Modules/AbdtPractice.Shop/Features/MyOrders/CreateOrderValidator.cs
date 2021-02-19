using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AbdtPractice.Core.Services;
using Force.Ccc;
using JetBrains.Annotations;

namespace AbdtPractice.Shop.Features.MyOrders
{
    [UsedImplicitly]
    public class CreateOrderValidator : IValidator<CreateOrder>
    {
        private readonly ICartStorage _cartStorage;
        private static readonly ValidationResult CartIsEmpty = new("Cart is empty");

        public CreateOrderValidator(ICartStorage cartStorage)
        {
            _cartStorage = cartStorage;
        }

        public IEnumerable<ValidationResult> Validate(CreateOrder obj)
        {
            yield return (_cartStorage.Cart.CartItems.Any()
                ? ValidationResult.Success
                : CartIsEmpty)!;
        }
    }
}
