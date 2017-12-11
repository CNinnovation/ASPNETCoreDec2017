using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConfigurationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupConfiguration(args);
            ReadConfiguration();
        }

        private static void ReadConfiguration()
        {
            string value = Configuration.GetSection("MySection1")["MySetting1"];
            Console.WriteLine(value);
            string booksConnection = Configuration.GetConnectionString("MyBooksConnection");
            Console.WriteLine(booksConnection);
            string setting2 = Configuration["setting2"];
            Console.WriteLine(setting2);
            string secret1 = Configuration["secret1"];
            Console.WriteLine(secret1);
        }

        private static void SetupConfiguration(string[] args)
        {
            string environment = "development";
            ConfigurationBuilder config =
                new ConfigurationBuilder();
            config.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json");
#if DEBUG
            config.AddUserSecrets("mySecrets47110815");  // dev only
#endif
            config.AddCommandLine(args);
            config.AddEnvironmentVariables();
            Configuration = config.Build();
        }

        public static IConfigurationRoot Configuration { get; private set; }
    }
}
