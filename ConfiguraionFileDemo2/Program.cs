using System;
using Microsoft.Extensions.Configuration;
namespace ConfiguraionFileDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange:true);
            builder.AddIniFile("appsetting.ini");
            builder.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);

            var configurationRoot = builder.Build();

            Console.WriteLine($"Key1: {configurationRoot["key1"]}");
            Console.WriteLine($"Key2: {configurationRoot["key2"]}");
            Console.WriteLine($"key3: {configurationRoot["key3"]}");
            Console.ReadKey();

            //Console.WriteLine($"Key1: {configurationRoot["key1"]}");
            //Console.WriteLine($"Key2: {configurationRoot["key2"]}");
            //Console.WriteLine($"key3: {configurationRoot["key3"]}");
            //Console.ReadKey();
        }
    }
}
