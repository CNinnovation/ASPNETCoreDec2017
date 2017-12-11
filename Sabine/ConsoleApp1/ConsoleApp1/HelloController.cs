using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class HelloController
    {
        private readonly IHelloService _helloService;
        public HelloController(IHelloService helloService)
        {
            _helloService = helloService;
        }

        public string Greeting(string name)
        {
            return _helloService.Hello(name);
        }
    }
}
