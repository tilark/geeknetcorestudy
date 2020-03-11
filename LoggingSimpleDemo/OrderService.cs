using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingSimpleDemo
{
    class OrderService
    {
        private readonly ILogger<OrderService> _logger;
        public OrderService(ILogger<OrderService> logger)
        {
            _logger = logger;
        }

        public void Show()
        {
            // 输出到Console时再拼接
            _logger.LogInformation("Show Time {time}", DateTime.Now);

            // 先拼接，再输出。 当不需要输出时，仍然会拼接，有性能损耗。
            _logger.LogInformation($"Show Time {DateTime.Now}");
        }
    }
}
