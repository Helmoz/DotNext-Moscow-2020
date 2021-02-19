using System;
using System.ComponentModel.DataAnnotations;
using Force.Ddd;
using Microsoft.AspNetCore.Mvc;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class MyOrdersListItem : HasIdBase
    {
        [Display(Name = "Id")]
        public override int Id { get; set; }

        [Display(Name = "Total")]
        public double Total { get; set; }

        [Display(Name = "Status")] 
        public string Status { get; set; } = default!;

        [HiddenInput]
        public DateTime Created { get; set; } = default!;

        [Display(Name = "Created")]
        public string CreatedString => Created.ToString("d");

        [Display(Name = "Comment")] 
        public string DisputeComment { get; set; } = default!;
    }
}
