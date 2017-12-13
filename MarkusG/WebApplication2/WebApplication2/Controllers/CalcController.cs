using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class CalcController : Controller
    {
        public int Add(int x, int y) => x + y;
    }
}