using IT_Store.Models;
using IT_Store.Repositories.Implements;
using IT_Store.Repositories.Interfaces;
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
			ConfigureServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "dashboard",
                pattern: "Admin/{action=Dashboard}",
                new { controller = "Admin" }
                );

            app.MapControllerRoute(
                name: "home",
                pattern:"{action=Index}/{id?}",
                new {controller="Home"}
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<CodexContext>(options =>
            {
                options.UseSqlServer("name=ConnectionStrings:development");
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IParentCategoryRepository, ParentCategoryRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

			services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<CodexContext>();
        }
    }
}
