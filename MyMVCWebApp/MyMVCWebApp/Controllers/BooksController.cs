using Microsoft.AspNetCore.Mvc;
using MyMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVCWebApp.Controllers
{
    public class BooksController : Controller
    {
        private List<Book> _books = new List<Book>
        {
            new Book { BookId = 1, Title = "Professional C# 6", Publisher = "Wrox Press"},
            new Book { BookId = 2, Title = "Professional C# 7", Publisher = "Wrox Press"},
        };

        public IActionResult Index()
        {
            // ViewData["MyData"] = "from the controller";
            ViewBag.MyData = "from the controller";
            return View(_books);
        }

        public IActionResult UsingALayout()
        {
            return View();
        }

        public IActionResult JsonSampleBooks()
        {
            return Json(_books);
        }

        public IActionResult ShowPartial()
        {
            return PartialView("MyPartialView");
        }

        public IActionResult MyBooksView()
        {
            var vm = new MyBooksViewModel();

            vm.Books = _books;
            vm.Title = "My Books View";
            return View(vm);
        }

        public IActionResult UseMyViewComponent() => View();

    }
}
