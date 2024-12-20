using Globalization.Middleware;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Globalization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

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

            app.UseRequestLocalization(options =>

            {

                // Define supported cultures and default culture

                var supportedCultures = new[]

                {

                    new CultureInfo("en-US"), // English (United States)

                    new CultureInfo("it"), // Italian
 
                // Add other supported cultures as needed

                };

                options.DefaultRequestCulture = new RequestCulture("en-US");

                options.SupportedCultures = supportedCultures;

                options.SupportedUICultures = supportedCultures;

            });

            app.UseMiddleware<LanguageMiddleware>();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
