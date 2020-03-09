using System;
using Microsoft.Extensions.Configuration;
namespace ConfigurationFileDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configurationRoot = builder.Build();

            Console.WriteLine($"Key1:{configurationRoot["Key1"]}");
            Console.WriteLine($"Key2:{configurationRoot["Key2"]}");
            Console.WriteLine($"Key3:{configurationRoot["Key3"]}");

            Console.ReadKey();

            Console.WriteLine($"Key1:{configurationRoot["Key1"]}");
            Console.WriteLine($"Key2:{configurationRoot["Key2"]}");
            Console.WriteLine($"Key3:{configurationRoot["Key3"]}");

            Console.ReadKey();
        }
    }
}
