using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class MyOrdersController : ApiControllerBase
    {
        [HttpPost("CreateNew")]
        [Authorize]
        public ActionResult<int> CreateNew([FromBody] CreateOrder query) =>
            this.Process(query);

        [HttpGet("GetMyOrders")]
        public ActionResult<IEnumerable<MyOrdersListItem>> GetMyOrders([FromQuery] GetMyOrdersQuery query) =>
            this.Process(query);

        [HttpPut("Dispute")]
        public async Task<IActionResult> Dispute(
            [FromBody] DisputeOrder command,
            [FromServices] Func<DisputeOrder, DisputeOrderContext> factory) =>
            await this.ProcessAsync(factory(command));

        [HttpPut("Complete")]
        public async Task<IActionResult> Complete(
            [FromBody] CompleteOrder command,
            [FromServices] Func<CompleteOrder, CompleteOrderContext> factory) =>
            await this.ProcessAsync(factory(command));

        [HttpPut("PayOrder")]
        public async Task<IActionResult> PayOrder(
            [FromBody] PayMyOrder command,
            [FromServices] Func<PayMyOrder, PayMyOrderContext> factory) =>
            await this.ProcessAsync(factory(command));
    }
}