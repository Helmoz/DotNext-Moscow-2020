using AbdtPractice.Admin.Features.OrderManagement;
using AbdtPractice.Core;
using AbdtPractice.Core.Entities;
using Infrastructure.SwaggerSchema.Dropdowns.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace AbdtPractice.Admin
{
    public static class AdminRegistrations
    {
        public static void RegisterAdmin(this IServiceCollection services)
        {
            services.AddScoped<IDropdownProvider<OrderListItem>, OrderListItemDropdownProvider>();
            
            services.AddOrderStateTransition<ShipOrder, Order.Paid, Order.Shipped>();
        }
    }
}