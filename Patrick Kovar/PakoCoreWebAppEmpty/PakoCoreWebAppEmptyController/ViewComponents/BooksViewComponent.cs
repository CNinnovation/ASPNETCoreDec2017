using Microsoft.AspNetCore.Mvc;
using PakoCoreWebAppEmptyController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakoCoreWebAppEmptyController.ViewComponents
{
    public class BooksViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string data, Book book) {

            // return Task.FromResult<IViewComponentResult>(View(data as object));

            // using tuple

            return Task.FromResult<IViewComponentResult>(View((data: data, book: book)));

        }

    }
}
