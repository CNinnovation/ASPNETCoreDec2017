using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Encodings.Web;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IFirstService, FirstService>();
            services.AddSingleton<SampleController>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMyMiddleware();

            app.Map("/caseMap", app2 =>
            {
                app2.Run(async context => {
                   await context.Response.WriteAsync("caseMap");
                });
            });

            app.Map("/caseQuery", app2 =>
            {
                app2.Run(async context => {
                    string sampleQuery= context.Request.Query["x"];
                    await context.Response.WriteAsync($"x=<h1>{sampleQuery}</h1>");
                });
            });

            app.Map("/caseScript", app2 =>
            {
                app2.Run(async context => {
                    string sampleQuery = context.Request.Query["x"];
                    string encoded = HtmlEncoder.Default.Encode(sampleQuery);
                    await context.Response.WriteAsync($"x=<h1>{encoded}</h1>");
                });
            });

            app.Map("/caseController", app2 =>
            {
                app2.Run(async context => {
                    var controller= app.ApplicationServices.GetRequiredService<SampleController>();
                    string sampleQuery = context.Request.Query["x"];
                    await context.Response.WriteAsync($"ControllerMessage={controller.Hello(sampleQuery)}");
                });
            });

            app.MapWhen((context) =>
            {
                return context.Request.Path.Value.Contains("mapwhentest");               
            },app2=> {                
                app2.Run(async context => {                
                    await context.Response.WriteAsync($"x=<h1>myMapWhen</h1>");
                });
            });

            app.Map("/Sample4", app2 =>
            {
                app2.Run(async context => {
                    string sampleQuery = context.Request.Form["text1"];
                    string encoded = HtmlEncoder.Default.Encode(sampleQuery);
                    await context.Response.WriteAsync($"x=<h1>{encoded}</h1>");
                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
