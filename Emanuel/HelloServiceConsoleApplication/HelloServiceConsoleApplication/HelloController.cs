using System;
using System.Collections.Generic;
using System.Text;

namespace HelloServiceConsoleApplication
{
    public class HelloController
    {
        public HelloController(IHelloService helloService)
        {
            _helloService = helloService;
        }


        private readonly IHelloService _helloService;

        public string Greeting()
        {
            return _helloService.Hello();
        }


    }
}
