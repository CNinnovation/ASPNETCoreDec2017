using Microsoft.AspNetCore.Mvc;
using MVCWithEFCore.Models;
using MVCWithEFCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWithEFCore.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    public class ApiBooksController : Controller
    {
        private readonly IBooksService _booksService;
        public ApiBooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _booksService.GetAllBooks().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = nameof(GetBook))]
        [ProducesResponseType(typeof(Book), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetBook(int id)
        {
            Book book = _booksService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(book);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Book), 201)]
        [ProducesResponseType(400)]
        public IActionResult PostBook([FromBody]Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            _booksService.AddBook(book);
       
            return CreatedAtRoute(nameof(GetBook),
              new { id = book.BookId }, book);
        }


    }
}
