﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        IOptionsMonitor<OrderServiceOptions> _options;
        public OrderService(IOptionsMonitor<OrderServiceOptions> options)
        {
            this._options = options;
            _options.OnChange(options =>
            {
                Console.WriteLine($"配置发生了变化，新值为：{options.MaxOrderCount }");
            });
        }
        public int ShowMaxOrderCount()
        {
            return _options.CurrentValue.MaxOrderCount;
        }
    }

    public class OrderServiceOptions
    {
        [Range(1, 200)]
        public int MaxOrderCount { get; set; } = 100;
    }

    public class OrderServiceValidateOptions: IValidateOptions<OrderServiceOptions>
    {
        public ValidateOptionsResult Validate(string name, OrderServiceOptions options)
        {
            if (options.MaxOrderCount > 200)
            {
                return ValidateOptionsResult.Fail("不能大于200");
            }
            else
            {
                return ValidateOptionsResult.Success;
            }
        }
    }
}
