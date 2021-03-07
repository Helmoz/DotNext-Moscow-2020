using AbdtPractice.Core.Base;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class DisputeOrder : ChangeOrderStateBase
    {
        public string Complaint { get; set; } = "";
    }
}