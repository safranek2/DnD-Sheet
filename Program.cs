using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.Extensions.FileSystemGlobbing.Internal;

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

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "guideHandlePath",
                pattern: "/CharacterCreator",
                defaults: new { controller = "Home", action = "CharacterCreator" });

            app.MapControllerRoute(
                name: "guides",
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
                name: "setLanguage",
                pattern: "/SetLanguage/{**lang}",
                defaults: new { controller = "Home", action = "SetLanguage" });

            app.MapControllerRoute(
                name: "default",
                pattern: "",
                defaults: new { controller = "Home", action = "Index" });

            app.MapFallbackToController("PageNotFound", "Home");

            app.Run();
        }
    }
}
