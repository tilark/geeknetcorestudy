using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
namespace ConfiguraionFileDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configurationRoot = builder.Build();

            IChangeToken token = configurationRoot.GetReloadToken();

            ChangeToken.OnChange(() =>
                configurationRoot.GetReloadToken(),
                () =>
                {
                    Console.WriteLine($"Key1: {configurationRoot["key1"]}");
                    Console.WriteLine($"Key2: {configurationRoot["key2"]}");
                    Console.WriteLine($"key3: {configurationRoot["key3"]}");
                }
            );
            Console.WriteLine("Begin");
            //token.RegisterChangeCallback(state =>
            //{
            //    Console.WriteLine($"Key1: {configurationRoot["key1"]}");
            //    Console.WriteLine($"Key2: {configurationRoot["key2"]}");
            //    Console.WriteLine($"key3: {configurationRoot["key3"]}");
            //}, configurationRoot);
            //Console.WriteLine($"Key1: {configurationRoot["key1"]}");
            //Console.WriteLine($"Key2: {configurationRoot["key2"]}");
            //Console.WriteLine($"key3: {configurationRoot["key3"]}");
            Console.ReadKey();

        }
    }
}
