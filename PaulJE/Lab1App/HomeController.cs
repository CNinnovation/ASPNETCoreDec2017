using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1App
{
    class HomeController
    {
        public string Hello(string name)
        {
            var service = new HelloService();

            return service.Greetings(name);

        }
    }
}
