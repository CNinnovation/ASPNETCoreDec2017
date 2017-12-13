using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionSample
{
    public class HomeController
    {
        private readonly IHelloService _helloService;
        public HomeController(IHelloService helloService)
        {
            _helloService = helloService;
        }

        public string Hello(string name)
        {
            
            return _helloService.Greeting(name);
        }
    }
}
