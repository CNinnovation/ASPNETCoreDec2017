using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // RunAppWithoutContainer();
            ConfigureServices();
            RunWithAContainer();
        }

        private static void RunWithAContainer()
        {
            var homeController = AppServices.GetRequiredService<HomeController>();
            string greet = homeController.Hello("Katharina");
            Console.WriteLine(greet);
        }

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IHelloService, HelloService>();
            services.AddTransient<HomeController>();

            AppServices = services.BuildServiceProvider();
        }

        public static IServiceProvider AppServices { get; private set; }
            

        private static void RunAppWithoutContainer()
        {
            IHelloService service = new HelloService();
            var controller = new HomeController(service);
            string greet = controller.Hello("Matthias");
            Console.WriteLine(greet);
        }
    }
}
