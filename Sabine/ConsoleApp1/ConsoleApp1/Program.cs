using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp1
{
    class Program
    {
        public static ServiceProvider AppServices { get; private set; }

        static void Main(string[] args)
        {
            ConfigureService();
            RunWithAContainer();
            //Console.WriteLine("Hello World!");
        }

        private static void RunWithAContainer()
        {
            var helloController = AppServices.GetRequiredService<HelloController>();
            string greet = helloController.Greeting("Katharina");
            Console.WriteLine(greet);
        }
        private static void ConfigureService()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IHelloService, HelloService>();
            services.AddTransient<HelloController>();

            AppServices = services.BuildServiceProvider();
        }
    }
}
