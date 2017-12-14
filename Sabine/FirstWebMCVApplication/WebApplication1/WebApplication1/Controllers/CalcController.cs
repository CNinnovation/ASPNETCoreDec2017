using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}