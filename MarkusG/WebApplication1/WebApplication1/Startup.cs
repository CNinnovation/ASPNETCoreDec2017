using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Controller;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICalcService, CalcService>();
            Container = services.BuildServiceProvider();
        }

        public IServiceProvider Container { get; set; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.Map("/SNES", app2 =>
            {
                app2.Run(async context =>
                {
                    await context.Response.WriteAsync("Metroid");
                });
            });

            app.Map("/Sample3", app2 =>
            {
                app2.Run(async context =>
                {
                    string x = context.Request.Query["x"];
                    //await context.Response.WriteAsync("Hello " + x);
                    //string ret = HtmlEncoder.Default.Encode(x);
                    double ret = app.ApplicationServices.GetService<ICalcService>().calcEuro2Dollar(Convert.ToDouble(x));
                    await context.Response.WriteAsync(Convert.ToString(ret));
                });
            });

            app.MapWhen(context =>
            {
                return context.Request.Path.Value.Contains("NES");
            }, app2 =>
            {
                app2.Run(async context =>
                {
                    await context.Response.WriteAsync("Mario");
                });
            }
            );

            app.Map("/Sample4", app2 =>
            {
                app2.Run(async context =>
                {
                    string text1 = context.Request.Form["text1"];
                    string res = HtmlEncoder.Default.Encode(text1);
                    await context.Response.WriteAsync(res);
                });
            });


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
