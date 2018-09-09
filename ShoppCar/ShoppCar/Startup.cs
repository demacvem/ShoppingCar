using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShoppCar.Data;
using ShoppCar.Data.Interfaces;
using ShoppCar.Data.Mocks;
using ShoppCar.Data.Models;
using ShoppCar.Data.Repositories;

namespace ShoppCar
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Server Configuration
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddTransient<IDrinkRepository, DrinkRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "categoryFilter", template: "Drink/{action}/{category?}", defaults: new { Controller = "Drink", action = "List" });
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });

            //DbInitializer.Seed(serviceProvider.GetRequiredService<AppDbContext>());
        }
    }
}
