using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PakoDIConsole;
using System;

namespace PakoDIConsoleContainer
{
    class Program
    {
        public static IServiceProvider MyServices { get; set; }

        static void Main(string[] args)
        {
            ConfigureServices();
            AppConfig();

            var helloController = MyServices.GetRequiredService<HelloController>();
            helloController.Greeting();

            Console.ReadLine();
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IHelloService, HelloService>();
            services.AddTransient<HelloController>();
            services.AddLogging(options =>
            {
                options.AddConsole();
            });

            MyServices = services.BuildServiceProvider();
        }

        private static void AppConfig()
        {

            

            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json");
            var config = configBuilder.Build();
            var outputString = config.GetSection("ConnectionStrings")["PakoConnection"];
            Console.WriteLine(outputString);

        }
    }
}
