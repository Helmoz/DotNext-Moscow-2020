using AbdtPractice.Core.Entities;

namespace AbdtPractice.Admin.Features.OrderManagement
{
    public class ShipOrderContext : BaseOrderContext<ShipOrder>
    {
        public ShipOrderContext(ShipOrder request, Order order) : base(request, order)
        {
        }
    }
}