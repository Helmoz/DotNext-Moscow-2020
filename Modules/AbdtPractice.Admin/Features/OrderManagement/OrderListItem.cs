using System;
using System.ComponentModel.DataAnnotations;
using AbdtPractice.Core.Entities;
using Force.Ddd;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace AbdtPractice.Admin.Features.OrderManagement
{
    public class OrderListItem : HasIdBase
    {
        static OrderListItem()
        {
            TypeAdapterConfig<Order, OrderListItem>
                .NewConfig()
                .Map(dest => dest.UserName, src => src.User.Email);
        }
        
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

        [Display(Name = "UserName")]
        public string UserName { get; set; } = default!;

        [Display(Name = "Comment")]
        public string? DisputeComment { get; set; }
    }
}