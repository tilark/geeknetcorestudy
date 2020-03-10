using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsDemo.Services
{
    public static class OrderServiceExtension
    {
        public static IServiceCollection AddOrderService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OrderServiceOptions>(configuration);
            services.AddSingleton<IOrderService, OrderService>();

            services.PostConfigure<OrderServiceOptions>(options =>
            {
                options.MaxOrderCount += 100;
            });
            return services;
        }
    }
}
