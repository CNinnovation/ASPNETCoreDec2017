using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakoCoreWebAppEmptyController.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsPublished { get; set; }


        //public IActionResult GetBook() {

        //    return Json();
        //}
    }
}
