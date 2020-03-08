using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DISimpleStudy.Services;
namespace DISimpleStudy.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private IOrderService orderService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IOrderService orderService, 
            IGenericService<IOrderService> genericService)
        {
            this.orderService = orderService;
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        public int Get([FromServices] IMySingletonService singleton1,
                                [FromServices] IMySingletonService singleton2,
                                [FromServices] IMyTransientService myTransient1,
                                [FromServices] IMyTransientService myTransient2,
                                [FromServices] IMyScopedService myScoped1,
                                [FromServices] IMyScopedService myScoped2)
        {
            Console.WriteLine($"singleton1: {singleton1.GetHashCode()}");
            Console.WriteLine($"singleton2: {singleton2.GetHashCode()}");
            Console.WriteLine($"Transient: {myTransient1.GetHashCode()}");
            Console.WriteLine($"Transient: {myTransient2.GetHashCode()}");
            Console.WriteLine($"Scoped: {myScoped1.GetHashCode()}");
            Console.WriteLine($"Scoped: {myScoped2.GetHashCode()}");

            Console.WriteLine($"=====请求结束====");
            return 1;

        }

        public int GetServiceList([FromServices] IEnumerable<IOrderService> orderServices)
        {
            foreach(var service in orderServices)
            {
                Console.WriteLine($"service:{service.ToString()}, {service.GetHashCode()}");

            }
            return 2;
        }
    }
}
