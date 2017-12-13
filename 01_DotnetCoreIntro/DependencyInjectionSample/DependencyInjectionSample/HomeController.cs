using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionSample
{
    public class HomeController
    {
        public string Hello(string name)
        {
            var service = new HelloService();
            return service.Greeting(name);
        }
    }
}
