using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace OdeToFood
{
    public class Startup
    {
        [Obsolete]
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables();
            Configuration = builder.Build();

        }
        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IHostingEnvironment envh,
            ILoggerFactory loggerFactory,
            IGreeter greeter)
        {
            // loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = context => context.Response.WriteAsync("Opps!")
                });
            }
            app.UseFileServer();
          //  app.UseDefaultFiles();
         //   app.UseStaticFiles();
            app.UseMvc(ConfigureRoutes);
            app.Run(ctx => ctx.Response.WriteAsync("Not found"));


            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path = "/welcome"
            //});
            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{


            //    endpoints.MapGet("/", async context =>
            //    {
            //    //   throw new Exception("Something went wrong!");
            //    var message = greeter.GetGreeting();
            //        await context.Response.WriteAsync(message);
            //    });
            //});


        }
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller = Home}/{action = Index}/{id?}");
        }
    }
}
