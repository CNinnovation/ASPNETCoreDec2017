using System;

namespace di_example
{
    public class HelloService : IHelloService
    {
        public string Hello(string name) => $"Hello, {name}";

    }
}
