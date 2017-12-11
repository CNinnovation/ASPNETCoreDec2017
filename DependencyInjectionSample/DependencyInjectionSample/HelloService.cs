using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionSample
{
    public class HelloService
    {
        public string Greeting(string name) => $"Hello, {name}";
    }
}
