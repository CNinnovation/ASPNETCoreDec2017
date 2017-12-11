using System;
using System.Collections.Generic;
using System.Text;

namespace PakoDIConsole
{
    class HelloService : IHelloService
    {
        public void Hello()
        {
            Console.WriteLine("Hallihallo!");
        }
    }
}
