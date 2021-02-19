using System;
using System.Collections.Generic;
using System.Net;
using AbdtPractice.Core.Entities;
using AbdtPractice.Core.Services;
using Force.Extensions;
using Infrastructure.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace AbdtPractice.Shop.Features.Cart
{
    public class CartController : ApiControllerBase
    {
        [HttpGet] 
        public ActionResult<List<CartItem>> Get([FromServices] ICartStorage storage) =>
            storage.Cart.CartItems.PipeTo(Ok);

        [HttpPut("Add")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult Add(
            [FromBody] int productId,
            [FromServices] Func<AddCartItem, AddCartItemContext> factory) =>
            this.Process(factory(new AddCartItem(productId)));

        [HttpPut("Remove")]
        public ActionResult<bool> Remove(
            [FromBody] int productId,
            [FromServices] Func<RemoveCartItem, RemoveCartItemContext> factory) =>
            this.Process(factory(new RemoveCartItem(productId)));
    }
}