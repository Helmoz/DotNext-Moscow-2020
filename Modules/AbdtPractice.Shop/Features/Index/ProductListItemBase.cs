using System;
using System.ComponentModel.DataAnnotations;
using AbdtPractice.Core.Entities;
using Force.Ddd;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace AbdtPractice.Shop.Features.Index
{
    public class ProductListItemBase<T>: HasIdBase<int>
        where T: ProductListItemBase<T>
    {
        static ProductListItemBase()
        {
            TypeAdapterConfig<Product, T>
                .NewConfig()
                .Map(dest => dest.Price, Product.DiscountedPriceExpression)
                .Map(dest => dest.CreatedString, src => src.Created.ToString("d"));
        }

        [Display(Name = "Id")]
        public override int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; } = default!;
        
        [Display(Name = "Category")]
        public string CategoryName { get; set; } = default!;

        [Display(Name = "Price")]
        public double Price { get; set; } = default!;

        [Display(Name = "Discount Percent")]
        public int DiscountPercent { get; set; }

        [Display(Name = "Date Created")]
        public string CreatedString => Created.ToString("d");

        [HiddenInput]
        public DateTime Created { get; set; }
    }
}