using System;
using System.Collections.Generic;
using System.Text;

namespace HelloServiceConsoleApplication
{
    public class HelloService : IHelloService
    {
        public string Hello()
        {
           return "hallo";
        }
    }
}
