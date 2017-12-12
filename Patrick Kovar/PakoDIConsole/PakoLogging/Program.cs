using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace PakoLogging
{
    class Program
    {
        public static IServiceProvider AppServices { get; private set; }
        private  readonly ILogger<Program> log;

     

        static void Main(string[] args)
        {
            Configure();
            var x = AppServices.GetService<Foo>();
            x.LogSth();
            Console.ReadLine();
        }

        private static void Configure()
        {
            var services = new ServiceCollection();
            services.AddTransient<Foo>();
            services.AddLogging(options =>
            {
                options.AddConsole();
            });
            AppServices = services.BuildServiceProvider();
        }
    }
}
