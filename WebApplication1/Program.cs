using WebApplication1.Filters;
using WebApplication1.Middlewares;

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
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<HandelExceptionFiterAttribute>();
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

            app.UseAuthorization();

            app.UseLoggingMiddlewareCustom();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
