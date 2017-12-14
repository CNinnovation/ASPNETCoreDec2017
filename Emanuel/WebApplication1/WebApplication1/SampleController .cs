using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class SampleController
    {
        private readonly IFirstService _firstService;

        public SampleController(IFirstService firstService)
        {
            _firstService = firstService;
        }

        public string Hello(string name)
        {
            return _firstService.greet(name);
        }

    }
}
