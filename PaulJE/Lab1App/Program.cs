using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Lab1App
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupConfig();
            ReadConfiguration();
            RunApp();
            //Console.WriteLine("Hello World!");
        }

        private static void ReadConfiguration()

        {
            //Username = Configuration.GetSection("MySection1")["Username"];
            Console.WriteLine(Username);
            string value = Configuration.GetSection("MySection1")["MySetting1"];
            Console.WriteLine(value);
            string booksConnection = Configuration.GetConnectionString("MyBooksConnection");
            Console.WriteLine(booksConnection);
            string setting2 = Configuration["setting2"];
            Console.WriteLine(setting2);
            string secret1 = Configuration["secret1"];
            Console.WriteLine(secret1);
        }

        private static void SetupConfig()
        {
            ConfigurationBuilder Config = new ConfigurationBuilder();
            Config.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("myappsettings.json");
            Console.WriteLine(Directory.GetCurrentDirectory());
        }

        private static void RunApp()
        {
            var controller = new HomeController();
            string greet = controller.Hello("Username: " + Username);
            Console.WriteLine(greet);
            Console.ReadLine();
        }
        public static IConfigurationRoot Configuration { get; private set; }
        public static String Username { get; private set; }
    }
}
