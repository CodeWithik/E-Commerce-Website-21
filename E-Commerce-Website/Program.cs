using E_Commerce_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add DB-Services with Connection String

            builder.Services.AddDbContext<myContext>(options => options.UseSqlServer(
             builder.Configuration.GetConnectionString("myconnection")));

            // Add cookies 

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Active Session 
            app.UseSession();

            // Normal Default Route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Admin}/{action=Index}/{id?}"
            );







            app.Run();
        }
    }
}
