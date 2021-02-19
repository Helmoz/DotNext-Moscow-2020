using System.Threading.Tasks;
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
        public async Task<IActionResult> PayOrder([FromBody] PayOrder command) =>
            await this.ProcessAsync(command);

        [HttpPut("Shipped")]
        public async Task<IActionResult> Shipped([FromBody] ShipOrder command) =>
            await this.ProcessAsync(command);

        [HttpPut("Complete")]
        public async Task<IActionResult> Complete([FromBody] CompleteOrderAdmin command) =>
            await this.ProcessAsync(command);
    }
}