
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggingSimpleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var config = builder.Build();

            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConfiguration>(p => config);

            serviceCollection.AddLogging(builder =>
            {
                builder.AddConfiguration(config.GetSection("Logging"));
                builder.AddConsole();
            });
            serviceCollection.AddTransient<OrderService>();
            IServiceProvider service = serviceCollection.BuildServiceProvider();

            var order = service.GetService<OrderService>();
            order.Show();
            ILoggerFactory loggerFactory = service.GetService<ILoggerFactory>();

            ILogger alogger = loggerFactory.CreateLogger("alogger");
            alogger.LogDebug(2001, "aiya");
            alogger.LogInformation("hello");

            var ex = new Exception("出错了");
            alogger.LogError(ex, "出错了!");
            Console.ReadKey();
        }
    }
}
