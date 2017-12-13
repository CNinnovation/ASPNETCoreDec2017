using Microsoft.AspNetCore.Mvc;
using MyMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVCWebApp.ViewComponents
{
    public class MyViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string data, Book book)
        {
            return Task.FromResult<IViewComponentResult>(View(data as object));
        }
    }
}
