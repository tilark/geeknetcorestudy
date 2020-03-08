using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
namespace OptionsDemo.Services
{
    public interface IOrderService
    {
        int ShowMaxOrderCount();
    }
    public class OrderService : IOrderService
    {
        IOptions<OrderServiceOptions> _options;
        public OrderService(IOptions<OrderServiceOptions> options)
        {
            this._options = options;
        }
        public int ShowMaxOrderCount()
        {
            return _options.Value.MaxOrderCount;
        }
    }

    public class OrderServiceOptions
    {
        public int MaxOrderCount { get; set; } = 100;
    }
}
