using System.ComponentModel.DataAnnotations;
using Force.Ddd;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class MyOrdersListItem : HasIdBase
    {
        [Display(Name = "Id")]
        public override int Id { get; set; }

        [Display(Name = "Total")]
        public double Total { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Created")]
        public string Created { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Comment")]
        public string DisputeComment { get; set; }
    }
}
