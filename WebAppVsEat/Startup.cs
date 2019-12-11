using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppVsEat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public object opts { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession();

            services.AddScoped<ICitiesManager, CitiesManager>();
            services.AddScoped<ICitiesDB, CitiesDB>();
            services.AddScoped<ICourierManager, CourierManager>();
            services.AddScoped<ICourierDB, CourierDB>();
            services.AddScoped<ICustomersManager, CustomersManager>();
            services.AddScoped<ICustomersDB, CustomersDB>();
            services.AddScoped<IDishesManager, DishesManager>();
            services.AddScoped<IDishesDB, DishesDB>();
            services.AddScoped<ILoginManager, LoginManager>();
            services.AddScoped<IloginDB, LoginDB>();
            services.AddScoped<IOrder_dishesManager, Order_dishesManager>();
            services.AddScoped<IOrder_dishesDB, Order_dishesDB>();
            services.AddScoped<IOrdersManager, OrdersManager>();
            services.AddScoped<IOrdersDB, OrdersDB>();
            services.AddScoped<IRestaurantsManager, RestaurantsManager>();
            services.AddScoped<IRestaurantsDB, RestaurantsDB>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Restaurant/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Restaurant}/{action=Index}/{id?}");
            });
        }
    }
}
