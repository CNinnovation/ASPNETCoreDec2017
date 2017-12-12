using MyFirstWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Controllers
{
    public class SimpleController
    {
        private readonly IGreetingService _greetingService;
        public SimpleController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }
        public string Hello(string name)
        {
            return _greetingService.Greet(name);
        }
    }
}
