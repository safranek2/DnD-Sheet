using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Collections.Generic;

namespace DnD_Sheet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            var app = builder.Build();

            var supportedCultures = new[] { "en", "cs" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "guidesIndex",
                pattern: "/Guides",
                defaults: new { controller = "Guides", action = "Guides" });

            app.MapControllerRoute(
                name: "guidesHandlePath",
                pattern: "/Guides/{**folderPath}",
                defaults: new { controller = "Guides", action = "Group" });

            app.MapControllerRoute(
                name: "guideHandlePath",
                pattern: "/Guide/{**filePath}",
                defaults: new { controller = "Guides", action = "GuideContent" });


            app.MapControllerRoute(
                name: "privacyPolicy",
                pattern: "/PrivacyPolicy",
                defaults: new { controller = "Home", action = "PrivacyPolicy" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
