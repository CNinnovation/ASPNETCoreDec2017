using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace PakoLogging
{
    class Program
    {
        public static IServiceProvider AppServices { get; private set; }
        private static readonly ILogger<Program> log;

        static void Main(string[] args)
        {
            Configure();
            var y = new LoggerFactory();
            log = y.CreateLogger<Program>();
            var x  = AppServices.GetRequiredService;
            
            MethodWithLogging();

           

            Console.ReadLine();
        }

        private static void Configure()
        {
            var services = new ServiceCollection();

            services.AddLogging(options =>
            {
                options.AddConsole();
            });
            AppServices = services.BuildServiceProvider();
        }

        private static void MethodWithLogging()
        {
            

            log.LogInformation("Bar started");
        }
    }
}
