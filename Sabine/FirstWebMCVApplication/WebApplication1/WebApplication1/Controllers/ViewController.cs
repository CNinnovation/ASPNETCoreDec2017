using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassingData1()
        {
            ViewBag.MyData = "This is my viewbag";
            return View("Index");
        }
    }
}