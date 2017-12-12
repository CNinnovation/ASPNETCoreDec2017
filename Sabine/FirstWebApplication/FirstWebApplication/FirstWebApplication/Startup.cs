using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using FirstWebApplication.Controllers;
using FirstWebApplication.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using FirstWebApplication.Middleware;

namespace FirstWebApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSession();
            services.AddSingleton<IGreetingService, GreetingService>();
            services.AddTransient<SimpleController>();
            //Container = services.BuildServiceProvider();
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
            app.UseMiddleware();

            app.MapWhen(context =>
            {
                return context.Request.Path.Value.Contains("mapwhen");
            }
            , app2 =>
            {
                app2.Run(async (context) =>
                {

                    await context.Response.WriteAsync("Contains: mapwhen");
                });
            });

            app.Map("/htmlaction", app2 =>
            {

                app2.Run(async (context) =>
                {
                    string form = context.Request.Form["text1"];
                    string encoded = HtmlEncoder.Default.Encode(form);
                    await context.Response.WriteAsync($"Form input: { encoded }");
                });
            });

            app.Map("/data", app2 =>
            {
                app2.Run(async (context) =>
                {
                    string data = context.Request.Query["mydata"];
                    string encoded = HtmlEncoder.Default.Encode(data);
                    await context.Response.WriteAsync($"Data: {  encoded }");
                });
            });

            app.Map("/simple", app2 =>
            {
                app2.Run(async (context) =>
                {

                    var controller = app.ApplicationServices.GetService<SimpleController>();
                    string name = context.Request.Query["name"];
                    string result = controller.Hello(name);

                    await context.Response.WriteAsync(result);


                });
            });
            app.Run(async (context) =>
            {

                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
