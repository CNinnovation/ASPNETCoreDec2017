using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakoCoreWebAppEmpty.Middleware
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;



        public MyMiddleware(RequestDelegate next)

        {

            _next = next;

        }



        public Task Invoke(HttpContext httpContext)

        {

            httpContext.Response.Headers.Add("mycustomheader", "my value");

            return _next(httpContext);

        }
    }
}
