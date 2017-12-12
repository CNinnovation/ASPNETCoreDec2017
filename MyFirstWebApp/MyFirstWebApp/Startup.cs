using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Encodings.Web;
using MyFirstWebApp.Services;
using MyFirstWebApp.Controllers;
using MyFirstWebApp.Middleware;

namespace MyFirstWebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get;  }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreetingService, GreetingService>();
            services.AddScoped<SimpleController>();
            services.AddDistributedMemoryCache();
            services.AddSession();
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
            app.UseMyHeaderMiddleware();
            app.UseSession();
            app.UseStaticFiles();

            app.Map("/Session", app2 =>
            {
                app2.Run(async context =>
                {
                    if (context.Request.Path.Value.Contains("one"))
                    {
                        context.Session.SetString("mysession1", "my data");
                        await context.Response.WriteAsync("session data written");
                    }
                    else
                    {
                        string sessiondata = context.Session.GetString("mysession1");
                        await context.Response.WriteAsync($"session data read: {sessiondata}");
                    }
                });
            });

            app.MapWhen(context =>
            {
                return context.Request.Path.Value.Contains("mapwhentest");
            }, app2 =>
            {
                app2.UseMyHeaderMiddleware();
                app2.Run(async context =>
                {
                    await context.Response.WriteAsync("MapWhen success");
                });
            });

            app.Map("/Simple", app2 =>
            {
                app2.Run(async context =>
                {
                    using (var scope = Container.CreateScope())
                    {
                        var controller = scope.ServiceProvider.GetService<SimpleController>();
                        string name = context.Request.Query["name"];
                        string result = controller.Hello(name);
                        await context.Response.WriteAsync(result);
                    }
                });
            });

            app.Map("/Calc", app2 =>
            {
                app2.Run(async context =>
                {
                    string x = context.Request.Query["x"];
                    string y = context.Request.Query["y"];
                    int result = int.Parse(x) + int.Parse(y);
                    await context.Response.WriteAsync($"<h1>Result: {result}</h1>");
                });
            });

            app.Map("/Enc", app2 =>
            {
                app2.Run(async context =>
                {
                    string data = context.Request.Query["data"];
                    string encoded = HtmlEncoder.Default.Encode(data);
                    await context.Response.WriteAsync(encoded);
                });
            });

            app.Map("/One", app2 =>
            {
                app2.Run(async context =>
                {
                    await context.Response.WriteAsync("<h1>From One</h1>");
                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<h1>Hello World!</h1>");
            });
        }
    }
}
