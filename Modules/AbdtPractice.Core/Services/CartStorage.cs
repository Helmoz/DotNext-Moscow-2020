using AbdtPractice.Core.Entities;
using AbdtPractice.Identity.Services;
using Force.Extensions;
using Microsoft.AspNetCore.Http;

namespace AbdtPractice.Core.Services
{
    public class CartStorage : ICartStorage
    {
        private static readonly string _cartKey = "Cart";
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserContext _userContext;

        private Cart _cart;

        public CartStorage(IHttpContextAccessor accessor, IUserContext userContext)
        {
            _accessor = accessor;
            _userContext = userContext;
        }

        public Cart Cart =>
            _cart ??= _accessor
                          .HttpContext
                          ?.Session
                          .Get<CartDto>(_cartKey)
                          .PipeTo(x => x.FromDto(_userContext.User))
                      ?? new Cart(_userContext.User);

        public void SaveChanges()
        {
            if (_cart != null)
                _accessor
                    .HttpContext
                    ?.Session
                    .Set(_cartKey, _cart.ToDto());
        }

        public void EmptyCart()
        {
            _accessor
                .HttpContext
                ?.Session
                .Remove(_cartKey);
        }
    }
}