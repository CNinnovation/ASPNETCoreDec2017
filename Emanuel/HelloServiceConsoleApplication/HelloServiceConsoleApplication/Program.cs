using Microsoft.Extensions.DependencyInjection;
using System;

namespace HelloServiceConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloController controller = new HelloController(new HelloService());
            Console.WriteLine(controller.Greeting());
            Container.AddSingleton<IHelloService, HelloService>();
            Container.AddTransient<HelloController>();
            AppService = Container.BuildServiceProvider();
            controller = AppService.GetService<HelloController>();
            Console.WriteLine(controller.Greeting());
        }

        private static IServiceCollection Container => new ServiceCollection();

        private static IServiceProvider AppService { get; set; }
    }
}
