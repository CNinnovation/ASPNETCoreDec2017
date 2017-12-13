using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace LoggingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureServices();
            var foo = AppServices.GetService<Foo>();
            foo.Bar();
            Console.ReadLine();
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<Foo>();
            services.AddLogging(options =>
            {
                options.AddConsole();
                options.AddDebug();
            });
            AppServices = services.BuildServiceProvider();
        }
        public static IServiceProvider AppServices { get; private set; }
    }
}
