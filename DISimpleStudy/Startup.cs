using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DISimpleStudy.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DISimpleStudy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Simple
            services.AddTransient<IMyTransientService, MyTransientService>();
            services.AddSingleton<IMySingletonService, MySingletonService>();
            services.AddScoped<IMyScopedService, MyScopeService>();
            #endregion

            #region »¨Ê½×¢²á
            services.AddSingleton<IOrderService>(new OrderService());
            //services.AddSingleton<IOrderService, OrderServiceEx>();
            #endregion

            #region ³¢ÊÔ×¢²á
            //services.TryAddSingleton<IOrderService, OrderServiceEx>();
            //services.TryAddEnumerable(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>());
            #endregion

            #region ÒÆ³ýºÍÌæ»»×¢²á
            //services.Replace(ServiceDescriptor.Singleton<IOrderService, OrderService>());
            //services.RemoveAll<IOrderService>();
            #endregion

            #region ×¢²á·ºÐÎ
            services.AddSingleton(typeof(IGenericService<>), typeof(GenericService<>));
            #endregion
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
