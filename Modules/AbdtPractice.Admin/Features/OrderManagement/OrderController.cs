using System;
using System.Threading.Tasks;
using AbdtPractice.Core.Base;
using AbdtPractice.Core.Entities;
using AbdtPractice.Shop.Features.MyOrders;
using Infrastructure.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbdtPractice.Admin.Features.OrderManagement
{
    public class OrderController : ApiControllerBase
    {
        [HttpGet()]
        [ProducesResponseType(typeof(OrderListItem), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] GetAllOrders query) =>
            this.Process(query);

        [HttpPut("PayOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PayOrder(
            [FromBody] PayOrder command, 
            [FromServices] Func<PayOrder, ChangeOrderStateContext<PayOrder, Order.New>> factory) =>
            await this.ProcessAsync(factory(command));

        [HttpPut("Shipped")]
        public async Task<IActionResult> Shipped(
            [FromBody] ShipOrder command,
            [FromServices] Func<ShipOrder, ChangeOrderStateContext<ShipOrder, Order.Paid>> factory) =>
            await this.ProcessAsync(factory(command));
    }
}