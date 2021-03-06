using System;
using System.ComponentModel.DataAnnotations;
using Force.Extensions;
using Infrastructure.Ddd.Domain;
using JetBrains.Annotations;

namespace AbdtPractice.Core.Entities
{
    public class OrderItem : IntEntityBase
    {
        [UsedImplicitly]
        protected OrderItem() { }

        public OrderItem(Order order, CartItem cartItem)
        {
            Order = order;
            Count = cartItem.Count;
            Name = cartItem.ProductName;
            Price = cartItem.Price;
            ProductId = cartItem.ProductId;
        }

        [Required] 
        public string Name { get; protected set; } = default!;

        public virtual Order Order { get; protected set; } = default!;

        public double Price { get; protected set; }

        public int Count { get; protected set; }

        public int ProductId { get; protected set; }
    }
}