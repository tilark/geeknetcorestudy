using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ConfigurationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { "key1", "value1" },
                {"key2", "value2" },
                {"section1:key4", "value4" },
                {"section2:key5", "value5" },
                {"section2:key6", "value6" },
                { "section2:section2_1:key7", "value7" }

        });

            IConfigurationRoot configurationRoot = builder.Build();

            //IConfiguration config = configurationRoot;

            Console.WriteLine(configurationRoot["key1"]);
            Console.WriteLine(configurationRoot["key2"]);

            IConfigurationSection section = configurationRoot.GetSection("section1");
            Console.WriteLine($"key4 is {section["key4"]}");
            Console.WriteLine($"key5 is {section["key5"]}");

            IConfigurationSection section2 = configurationRoot.GetSection("section2");
            Console.WriteLine($"section2 key5 is {section2["key5"]}");

            IConfigurationSection section2_1 = section2.GetSection("section2_1");
            Console.WriteLine($"key7 is {section2_1["key7"]}");

        }
    }
}
