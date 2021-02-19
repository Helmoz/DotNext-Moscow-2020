using System;
using System.Collections.Generic;
using AbdtPractice.Core.Entities;

namespace AbdtPractice.Core.Services
{
    public class CartDto
    {
        public Guid Id { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}