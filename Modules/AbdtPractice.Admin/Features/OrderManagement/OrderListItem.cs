﻿using System.ComponentModel.DataAnnotations;
using AbdtPractice.Core.Entities;
using Force.Ddd;
using Mapster;

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
        public string Status { get; set; }

        [Display(Name = "Created")]
        public string Created { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Comment")]
        public string DisputeComment { get; set; }
    }
}