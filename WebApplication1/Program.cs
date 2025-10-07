using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Filters;
using WebApplication1.GenericRepo;
using WebApplication1.IGenericRepo;
using WebApplication1.IRepo;
using WebApplication1.Middlewares;
using WebApplication1.Models;
using WebApplication1.Repositry;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Session
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // builder.Services.AddMemoryCache();
            builder.Services.AddResponseCaching();

            //HandelExceptionFiterAttribute global
            //builder.Services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add<HandelExceptionFiterAttribute>();
            //});

            //Register Our Own Service
            //builder.Services.AddScoped<IStudentRepo, StudentRepo>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(op =>
            {
                op.Password.RequiredLength = 4;
                op.Password.RequireNonAlphanumeric = false;
                op.Password.RequireUppercase = false;
                op.Password.RequireLowercase = false;
                op.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<TantaMVCContext>();

            builder.Services.AddScoped<GenericStudentRepo>();
            builder.Services.AddScoped<GenericDepartment>();


            //DBContext
            builder.Services.AddDbContext<TantaMVCContext>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
            });


            var app = builder.Build();
            app.UseResponseCaching();

            app.UseSession();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // app.UseLoggingMiddlewareCustom();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
