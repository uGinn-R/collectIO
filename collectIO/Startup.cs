using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using collectIO.Services;
using Microsoft.EntityFrameworkCore;
using Westwind.AspNetCore.Markdown;
using Microsoft.AspNetCore.Identity;
using collectIO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.DataProtection;
using System.IO;

namespace collectIO
{
    public class Startup
    {
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _environment;
        public string _path_ { get; set; }
        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
            _path_ = Path.Combine(_environment.ContentRootPath, "Keys");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CollectioDbConnection"));
            });


            //services.AddAuthentication();
            //services.AddAuthorization();
            //        services.AddDataProtection()
            //.PersistKeysToFileSystem(new DirectoryInfo(_path_))
            //.SetApplicationName("collectIO");
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = ".AspNetCore.Identity.Application";
            //});

            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddRazorPages();
            //services.AddSingleton<ICollectionRepository, MockCollectionRepository>();
            services.AddScoped<ICollectionRepository, SQLCollectionRepository>();
            services.AddMarkdown();
            services.AddSignalR();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMarkdown();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            //app.UseCookiePolicy(new CookiePolicyOptions
            //{
            //    HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.None,
            //    MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None,
            //    Secure = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always
            //});

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
               // endpoints.MapControllerRoute("default", "/{action=Index}");
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chatHub");
            });

        }
    }
}
