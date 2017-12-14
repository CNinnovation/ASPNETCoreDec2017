using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IBooksRepository, BooksRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default",
                    template: "{controller}/{action}/{name?}",
                    defaults: new { controller = "Home", action = "Index"} );

                routes.MapRoute("UseMVC",
                    template: "Math/{action}/{x}/{y}",
                    defaults: new { controller = "Calc" });

                routes.MapRoute("Views",
                    template: "Demo/{action}",
                    defaults: new { controller = "View", action = "Index" });

                routes.MapRoute("Redirect",
                    template: "Redirect",
                    defaults: new { controller = "Redirect", action = "Index" });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
