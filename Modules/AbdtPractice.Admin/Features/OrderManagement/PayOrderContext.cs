using AbdtPractice.Core.Entities;

namespace AbdtPractice.Admin.Features.OrderManagement
{
    public class PayOrderContext : BaseOrderContext<PayOrder>
    {
        public PayOrderContext(PayOrder request, Order order) : base(request, order)
        {
        }
    }
}