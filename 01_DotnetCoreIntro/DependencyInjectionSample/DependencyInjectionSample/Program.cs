using System;

namespace DependencyInjectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            RunApp();
        }

        private static void RunApp()
        {
            var controller = new HomeController();
            string greet = controller.Hello("Stephanie");
            Console.WriteLine(greet);
        }
    }
}
