using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PakoCoreWebAppEmptyController.Models;

namespace PakoCoreWebAppEmptyController.Controllers
{
    public class ViewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassingData1() {
            ViewBag.MyPersonalData = "Meine persönlichen Daten - yeah.";
            return View();
        }

        public IActionResult PassingData2() {
            Book myBook = new Book() { Title = "abc", Author = "asdfasdf asdfasdf", IsPublished = false };
            return View(myBook);
        }

        public IActionResult UsingLayout() {
            return View();
        }
    }
}