using Microsoft.AspNetCore.Mvc;
using PakoCoreWebAppEmptyController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace PakoCoreWebAppEmptyController.Controllers {
    public class HomeController : Controller {

        public IBooksRepository BookRepository{ get; set; }

        public HomeController(IBooksRepository bookRepo) {
            this.BookRepository = bookRepo;
        }

        public string Index() {

            return "Hallo von der Index Methode!";
        }

        public string Greeting1(string irgendwos) {
            return "Hello, " + irgendwos;
        }

        public string Greeting2(string name) {
            return "Hello, " + name;
        }

        public int Add(int x, int y) {
            //var sum = int.Parse(x) + int.Parse(y);
            var sum = x + y;
            return sum;
        }


        public IActionResult GetBook() {
            var book = BookRepository.GetBook();
            return Json(book);
        }


     


    }
}
