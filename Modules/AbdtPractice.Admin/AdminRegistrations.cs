using AbdtPractice.Admin.Features.OrderManagement;
using AbdtPractice.Shop.Features.MyOrders;
using Infrastructure.SwaggerSchema.Dropdowns.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace AbdtPractice.Admin
{
    public static class AdminRegistrations
    {
        public static void RegisterAdmin(this IServiceCollection services)
        {
            services.AddScoped<IDropdownProvider<PayOrder>, PayOrderDropdownProvider>();
            services.AddScoped<IDropdownProvider<OrderListItem>, OrderListItemDropdownProvider>();
        }
    }
}