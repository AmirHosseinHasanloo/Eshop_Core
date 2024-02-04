using DataLayer;
using Eshop_Core.Utilties;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Core.Services.Interfaces;
using Core.Services;
using System.Net;

namespace Eshop_Core
{
    public class Startup
    {

        public IConfiguration _Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            #region DbContext
            services.AddDbContext<EshopContext>(options =>
            {
                options.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Session
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = "Eshop_Session";
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.IsEssential = true;
            });
            #endregion

            #region IoC
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IFeaturesService, FeaturesService>();
            services.AddScoped<IProductGroupService, ProductGroupService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddTransient<IViewRenderService, RenderViewToString>();

            #endregion

            #region Authentication

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            });

            #endregion
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();


            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
