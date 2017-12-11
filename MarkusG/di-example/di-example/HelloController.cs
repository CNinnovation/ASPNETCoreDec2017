using System;

namespace di_example
{
    public class HelloController
    {
        private readonly IHelloService _service;

        public HelloController(IHelloService service)
        {
            _service = service;
        }

        public string Greeting(string name)
        {
            return _service.Hello(name);
        }
    }
}