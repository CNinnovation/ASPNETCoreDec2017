using PakoCoreWebAppEmpty.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakoCoreWebAppEmpty.Controller
{
    public class CustomController
    {
        private readonly ICustomService _greetingService;

        public CustomController(ICustomService greetingService)

        {

            _greetingService = greetingService;

        }

        public string Hello(string name)

        {

            return _greetingService.Greet(name);

        }
    }
}
