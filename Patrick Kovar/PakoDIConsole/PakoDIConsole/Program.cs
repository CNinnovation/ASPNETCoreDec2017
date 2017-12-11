using System;

namespace PakoDIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var concreteService = new HelloService();
            var controller = new HelloController(concreteService);
            controller.Greeting();
            Console.ReadLine();
        }
    }
}
