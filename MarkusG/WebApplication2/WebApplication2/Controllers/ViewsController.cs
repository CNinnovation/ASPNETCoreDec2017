using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ViewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassingData1()
        {
            ViewData["test"] = "abc";
            return View(ViewData["test"]);
        }

        public IActionResult PassingData2()
        {
            return View(new Book(4, "Hello World", 800));
        }
    }
}