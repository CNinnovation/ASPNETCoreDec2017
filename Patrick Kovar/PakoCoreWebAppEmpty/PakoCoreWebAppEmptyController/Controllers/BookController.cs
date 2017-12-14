using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PakoCoreWebAppEmptyController.Models;

namespace PakoCoreWebAppEmptyController.Controllers
{
    public class BookController : Controller
    {
        public IActionResult GetBook()
        {
            var book = new Book() { Title = "BuchTitel", Author = "Pako", IsPublished = true };
            return Json(book);
        }

        public IActionResult RedirectToWebsite() {

            return Redirect("http://www.cninnovation.com");
        }

        public IActionResult UseViewComponent() {

            return View();
        }
    }
}