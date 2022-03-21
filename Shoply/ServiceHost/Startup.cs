using _01_framwork.Applicatin;
using _01_framwork.Infrastructure;
using AcountManagement.Infrastructure.Configuration;
using BlogManagement.Infrastructure.Config;
using CommentManagement.Infrastructure.Config;
using DiscountManagement.Infrastructure.Config;
using InventoryManagement.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopManagment.Imfrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace ServiceHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            var connectionString = Configuration.GetConnectionString("ShoplyDb");
            ShopManagementConfiguration.Configur(services, connectionString);
            DiscountManagementBootstraper.Configur(services, connectionString);
            InventoryManagementBootstraper.Configur(services, connectionString);
            BlogBootstrapper.Configur(services, connectionString);
            CommenManagementtBootstraper.Configur(services, connectionString);
            AcountManagementBootstarpper.Configur(services, connectionString);



            services.AddTransient<IAuthHelper, AuthHelper>();
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IFileUploader, FileUploader>();



            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Acount");
                    o.LogoutPath = new PathString("/Acount");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });

            services.AddAuthorization(option =>
            {
                option.AddPolicy("AdminArea", builder => builder.RequireRole(Rols.Administrator, Rols.ContentUploader));
                option.AddPolicy("Acounts", builder => builder.RequireRole(Rols.Administrator));
                //option.AddPolicy("Inventory", builder => builder.RequireRole(Rols.Administrator));
                option.AddPolicy("ColleagueDiscount", builder => builder.RequireRole(Rols.Administrator));
            });

            services.AddRazorPages()
               .AddMvcOptions(option => option.Filters.Add<PageFilter>())
               .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
                    options.Conventions.AuthorizeAreaFolder("Administration", "/Acounts", "Acounts");
                    //options.Conventions.AuthorizeAreaFolder("Administration", "/Inventory", "Inventory");
                    options.Conventions.AuthorizeAreaPage("Administration", "/Discount/ColleagueDiscount/Index", "ColleagueDiscount");

                });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
