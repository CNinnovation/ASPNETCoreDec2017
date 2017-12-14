using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PakoCoreWebAppEmpty.Controller;
using PakoCoreWebAppEmpty.Middleware;
using PakoCoreWebAppEmpty.Services;

namespace PakoCoreWebAppEmpty
{
    public class Startup
    {
        public IServiceProvider Container { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomService, CustomService>();
            services.AddTransient<CustomController>();
            Container = services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //custom Middlware zwischenschalten
            //ohne Extension Method:
            //app.UseMiddleware<MyMiddleware>();
            //mit Extension Method:
            app.UseMyMiddleware();


            //statische Files aktivieren (direkter aufruf von helloWorld.html)
            app.UseStaticFiles();

            //Mapping für "/test"
            app.Map("/test", app2 => app2.Run(async (context) =>
           {
               await context.Response.WriteAsync("<h1>Willkommen auf der Testseite!</h1>");
           }));

            //Mapping für "/Sample3"
            app.Map("/Sample3", app2 => app2.Run(async (context) =>
            {
                var x = context.Request.Query["x"];
                var encodedString = HtmlEncoder.Default.Encode(x);
                await context.Response.WriteAsync($"<h1>Variable x = {encodedString}</h1>");
            }));

            //Mapping für "/CustController"
            app.Map("/CustController", app2 => app2.Run(async (context) =>
            {
                //var custController = Container.GetService<CustomController>();
                //oder
                var custController = app.ApplicationServices.GetService<CustomController>();
                var greeting = custController.Hello("Pako");
                await context.Response.WriteAsync($"<h1>{greeting}</h1>");
            }));

            //Mapping für "/myForm"
            app.Map("/myForm2", app2 => app2.Run(async (context) =>
            {
                var encodedString = HtmlEncoder.Default.Encode((context.Request.Form["text1"]));
                await context.Response.WriteAsync(encodedString);               
            }));

            //MapWhen
            app.MapWhen((context) => 
            {
                return context.Request.Path.Value.Contains("mapwhen");
            },
                app2 => app2.Run(async (context) => 
                {
                    await context.Response.WriteAsync("MapWhen? Success!");
                }));

            //Default:
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
