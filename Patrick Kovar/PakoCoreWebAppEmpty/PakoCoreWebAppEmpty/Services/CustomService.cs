using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakoCoreWebAppEmpty.Services
{
    public class CustomService : ICustomService
    {
       
        public string Greet(string name) => $"Hello, {name}";
        


    }
}
