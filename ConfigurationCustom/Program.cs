using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace ConfigurationCustom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var builder = new ConfigurationBuilder();
            //builder.Add(new MyConfigurationSource());
            builder.AddMyConfiguration();

            var configurationRoot = builder.Build();

            ChangeToken.OnChange(() =>
            configurationRoot.GetReloadToken(),
            () =>
            {
                Console.WriteLine($"lastTime is {configurationRoot["lastTime"]}");

            });
            Console.WriteLine("Begin");
            Console.ReadKey();
        }
    }
}
