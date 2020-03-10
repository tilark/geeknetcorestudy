using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
            //services.Configure<OrderServiceOptions>(configuration);
            services.AddOptions<OrderServiceOptions>().Configure(options =>
           {
               configuration.Bind(options);
           }).Validate(options =>
           {
               return options.MaxOrderCount <= 200;
           }, "MaxOrderCount不能大于200");
            services.PostConfigure<OrderServiceOptions>(options =>
            {
                options.MaxOrderCount += 1;
            });
            services.AddSingleton<IOrderService, OrderService>();

            
            return services;
        }
    }
}
