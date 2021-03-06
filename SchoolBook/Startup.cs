using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using SchoolBook.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolBook.Models;
using SchoolBook.Areas.Identity;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SchoolBook.DAL;
using System.Security.Claims;
using SchoolBook.Utils;
using System.Globalization;

namespace SchoolBook
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name)),
                ServiceLifetime.Transient);

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDefaultIdentity<User>(options =>
                    {
                        options.Password.RequireDigit = false;
                        options.Password.RequiredLength = 6;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                        options.User.AllowedUserNameCharacters = null;
                        options.SignIn.RequireConfirmedAccount = false;
                        options.SignIn.RequireConfirmedEmail = false;
                    })
                .AddRoles<IdentityRole>()
                //.AddUserStore<CustomUserStore>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddLogging();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddHttpContextAccessor();

            services.TryAddTransient<IMenuOptionsDAL, MenuOptionsDAL>();
            services.TryAddTransient<IBulletinsDAL, BulletinsDAL>();
            services.TryAddTransient<IUsersDAL, UsersDAL>();
            services.TryAddTransient<IStudentsDAL, StudentsDAL>();
            services.TryAddTransient<ISubjectsDAL, SubjectsDAL>();
            services.TryAddTransient<IPeriodsDAL, PeriodsDAL>();
            services.TryAddTransient<IEvaluationsDAL, EvaluationsDAL>();
            services.TryAddTransient<IAuthorizationRequestDAL, AuthorizationRequestDAL>();

            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.TryAddScoped(s => s.GetService<IHttpContextAccessor>().HttpContext.User);

            services.ConfigureApplicationCookie(options => options.LoginPath = "/Home");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<User> userManager, ApplicationDbContext dbContext, ILogger<ApplicationDbContext> logger, IActionContextAccessor httpContextAccessor, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            loggerFactory.AddProvider(new LoggerDatabaseProvider(Configuration, httpContextAccessor));

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            var cultureInfo = new CultureInfo("es-CL");
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            //ApplicationDbContext.SeedUsersAsync(userManager, dbContext, logger).GetAwaiter().GetResult();
        }
    }
}
