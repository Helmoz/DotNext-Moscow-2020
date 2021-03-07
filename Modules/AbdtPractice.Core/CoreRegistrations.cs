using System;
using System.Threading.Tasks;
using AbdtPractice.Core.Base;
using AbdtPractice.Core.Entities;
using Force.Cqrs;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using Microsoft.Extensions.DependencyInjection;

namespace AbdtPractice.Core
{
    public static class CoreRegistrations
    {
        public static void RegisterCore(this IServiceCollection services) { }

        public static IServiceCollection AddOrderStateTransition<TCommand, TFrom, TTo>(
            this IServiceCollection services)
            where TFrom : Order.OrderStateBase
            where TTo : Order.OrderStateBase
            where TCommand : class, ICommand<Task<HandlerResult<OrderStatus>>>, IHasOrderId
        {
            services.AddScoped<
                ICommandHandler<ChangeOrderStateContext<TCommand, TFrom>, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<TCommand, TFrom, TTo>>();

            var funcType = typeof(Func<TCommand, ChangeOrderStateContext<TCommand, TFrom>>);
            var factoryType = typeof(OperationContextFactory<TCommand, ChangeOrderStateContext<TCommand, TFrom>>);
            
            services.AddScoped(factoryType);
            services.AddScoped(funcType, sp => ((dynamic) sp.GetService(factoryType)).BuildFunc(sp) );

            return services;
        }
    }
}