using _0_Framework.Application.ZarinPal;
using _01_framwork.Applicatin;
using _01_framwork.Applicatin.Email;
using _01_framwork.Applicatin.Sms;
using _01_framwork.Applicatin.TokenAuthorize;
using _01_framwork.Applicatin.ZarinPal;
using _01_framwork.Infrastructure;
using AcountManagement.Infrastructure.Configuration;
using AcountManagement.presentation.Api;
using BlogManagement.Infrastructure.Config;
using CommentManagement.Infrastructure.Config;
using DiscountManagement.Infrastructure.Config;
using InventoryManagement.Infrastructure.Configuration;
using InventoryManagement.Presentation.Api;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopManagement.Presentation.Api;
using ShopManagment.Imfrastructure.Config;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            services.AddShopSection(connectionString);
            services.AddDisCountSection(connectionString);
            services.AddInventorySection(connectionString);
            services.AddBlogSection(connectionString);
            services.AddAcountSection(connectionString);
            services.AddCommentSection(connectionString);

            services.AddTransient<IAuthHelper, AuthHelper>();
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IFileUploader, FileUploader>();
            services.AddTransient<IZarinPalFactory, ZarinPalFactory>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddSingleton<ITokenManagement, TokenManagement>();
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
                    //o.ReturnUrlParameter = new PathString("/AccessDenied");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});



            services.AddAuthorization(option =>
            {
                option.AddPolicy("AdminArea", builder => builder.RequireRole(Rols.Administrator, Rols.ContentUploader, Rols.SaleManager));
                option.AddPolicy("Acounts", builder => builder.RequireRole(Rols.Administrator));
                option.AddPolicy("Inventory", builder => builder.RequireRole(Rols.Administrator, Rols.SaleManager, Rols.ContentUploader));
                option.AddPolicy("ColleagueDiscount", builder => builder.RequireRole(Rols.Administrator, Rols.SaleManager));
                option.AddPolicy("Order", builder => builder.RequireRole(Rols.Administrator, Rols.SaleManager));
            });

            services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddRazorPages()
               .AddMvcOptions(option => option.Filters.Add<PageFilter>())
               .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
                    options.Conventions.AuthorizeAreaFolder("Administration", "/Acounts", "Acounts");
                    options.Conventions.AuthorizeAreaFolder("Administration", "/Inventory", "Inventory");
                    options.Conventions.AuthorizeAreaFolder("Administration", "/Shop/Order", "Order");
                    options.Conventions.AuthorizeAreaPage("Administration", "/Discount/ColleagueDiscount/Index", "ColleagueDiscount");
                })
               .AddApplicationPart(typeof(ProductController).Assembly)
               .AddApplicationPart(typeof(AuthorizeController).Assembly)
               .AddApplicationPart(typeof(AcountController).Assembly)
               .AddApplicationPart(typeof(InventoryController).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseCors("MyPolicy");
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
