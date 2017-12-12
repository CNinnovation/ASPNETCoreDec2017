using System;
using Microsoft.Extensions.DependencyInjection;

namespace di_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Config();
            Container();
        }

        public static IServiceProvider AppServices { get; private set; }

        private static void Container()
        {
            var container = AppServices.GetRequiredService<HelloController>();
            string greet = container.Greeting("Manu");
            Console.WriteLine(greet);
            Console.ReadLine();
        }

        public static void Config()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IHelloService, HelloService>();
            services.AddTransient<HelloController>();

            AppServices = services.BuildServiceProvider();
        }

        private static void noCont()
        {
            var controller = new HelloController(new HelloService());
            string greet = controller.Greeting("Markus");
            Console.WriteLine(greet);
            Console.ReadLine();
        }
    }
}
