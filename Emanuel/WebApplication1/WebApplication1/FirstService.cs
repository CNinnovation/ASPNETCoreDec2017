using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class FirstService : IFirstService
    {
        public string greet(string name)
        {
            return name;
        }
    }
}
