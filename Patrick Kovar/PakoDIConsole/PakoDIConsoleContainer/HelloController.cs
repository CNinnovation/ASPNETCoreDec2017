using System;
using System.Collections.Generic;
using System.Text;

namespace PakoDIConsole
{
    public class HelloController
    {
        public IHelloService Service { get; set; }
        public HelloController(IHelloService service)
        {
            this.Service = service;
        }

        public void Greeting()
        {
            Service.Hello();
        }
    }
}
