using IT_Store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IT_Store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            AddServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name:"admin",
                pattern: "admin/{action=Dashboard}",
                new {controller="Admin"}
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
        private static void AddServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<CodexContext>(options =>
            {
                options.UseSqlServer("name=ConnectionStrings:development");
            });

            services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<CodexContext>();
        }
    }
}
