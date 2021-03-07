using AbdtPractice.Core;
using AbdtPractice.Core.Entities;
using AbdtPractice.Core.Services;
using AbdtPractice.Shop.Features.Cart;
using AbdtPractice.Shop.Features.Catalog;
using AbdtPractice.Shop.Features.Index;
using AbdtPractice.Shop.Features.MyOrders;
using Infrastructure.SwaggerSchema.Dropdowns.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace AbdtPractice.Shop
{
    public static class ShopRegistrations
    {
        public static void RegisterShop(this IServiceCollection services)
        {
            services.AddScoped<ICartStorage, CartStorage>();
            
            services
                .AddOrderStateTransition<PayOrder, Order.New, Order.Paid>()
                .AddOrderStateTransition<DisputeOrder, Order.Shipped, Order.Disputed>()
                .AddOrderStateTransition<CompleteOrder, Order.Shipped, Order.Complete>();

            services.AddScoped<IDropdownProvider<ProductListItem>, ProductsDropdownProvider>();
            services.AddScoped<IDropdownProvider<BestsellersListItem>, BestsellersDropdownProvider>();
            services.AddScoped<IDropdownProvider<NewArrivalsListItem>, NewArrivalsDropdownProvider>();
            services.AddScoped<IDropdownProvider<SaleListItem>, SaleListDropdownProvider>();
            services.AddScoped<IDropdownProvider<CartItem>, CartDropdownProvider>();
            services.AddScoped<IDropdownProvider<MyOrdersListItem>, MyOrdersListItemDropdownProvider>();
        }
    }
}