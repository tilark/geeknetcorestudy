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

            var config = new Config()
            {
                Key1 = "config key1",
                Key5 = false
            };

            //configurationRoot.Bind(config);
            configurationRoot.GetSection("OrderService").Bind(config,
                binderOptions => { binderOptions.BindNonPublicProperties = true; }
                );
            Console.WriteLine($"Key1: {config.Key1}");
            Console.WriteLine($"Key2: {config.Key5}");
            Console.WriteLine($"key3: {config.Key6}");


            #region ChangeToken.OnChange


            //IChangeToken token = configurationRoot.GetReloadToken();

            //ChangeToken.OnChange(() =>
            //    configurationRoot.GetReloadToken(),
            //    () =>
            //    {
            //        Console.WriteLine($"Key1: {configurationRoot["key1"]}");
            //        Console.WriteLine($"Key2: {configurationRoot["key2"]}");
            //        Console.WriteLine($"key3: {configurationRoot["key3"]}");
            //    }
            //);
            //Console.WriteLine("Begin");
            #endregion

            #region RegisterChangeCallback
            //token.RegisterChangeCallback(state =>
            //{
            //    Console.WriteLine($"Key1: {configurationRoot["key1"]}");
            //    Console.WriteLine($"Key2: {configurationRoot["key2"]}");
            //    Console.WriteLine($"key3: {configurationRoot["key3"]}");
            //}, configurationRoot);
            //Console.WriteLine($"Key1: {configurationRoot["key1"]}");
            //Console.WriteLine($"Key2: {configurationRoot["key2"]}");
            //Console.WriteLine($"key3: {configurationRoot["key3"]}");
            #endregion

            Console.ReadKey();

        }
    }

    class Config
    {
        public string Key1 { get; set; }
        public bool Key5 { get; set; } = false;
        public int Key6 { get; private set; } = 100;
    }
}
