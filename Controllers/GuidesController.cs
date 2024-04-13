using DnD_Sheet.Models;
using Markdig;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DnD_Sheet.Controllers
{
    public class GuidesController : Controller
    {
        private readonly ILogger<GuidesController> _logger;

        public GuidesController(ILogger<GuidesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Guides()
        {
            var (directories, files) = GetDirectoriesAndFiles();
            var model = new GroupViewModel { Directories = directories, Files = files };
            return View(model);
        }

        public IActionResult Group(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath))
                return RedirectToAction("Guides");

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Guides", folderPath.Replace('/', Path.DirectorySeparatorChar));

            if (!Directory.Exists(fullPath))
                return RedirectToAction("PageNotFound", "Home");

            if (System.IO.File.Exists(fullPath))
                return GuideContent(folderPath);

            var (directories, files) = GetDirectoriesAndFiles(fullPath);
            var model = new GroupViewModel { Directories = directories, Files = files };
            return View(model);
        }

        public IActionResult GuideContent(string filePath)
        {

            Console.WriteLine(filePath);

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Guides", filePath.Replace('/', Path.DirectorySeparatorChar) + ".md");

            if (!System.IO.File.Exists(fullPath))
                return RedirectToAction("PageNotFound", "Home");

            string htmlContent = "";
            string extension = "en";

            string languageCookie = HttpContext.Request.Cookies[".AspNetCore.Culture"];
            string language = languageCookie?.Substring(languageCookie.Length - 2);

            if (language == "en")
            {
                extension = ".md";
            }
            else
            {
                extension = "." + language + ".md";
            }

            string specificFilePath = Path.ChangeExtension(fullPath, extension);
            if (System.IO.File.Exists(specificFilePath))
            {
                fullPath = specificFilePath;
            }
            else
            {
                extension = ".md";
            }

            if (extension == ".md" || extension == ".cs.md")
            {
                string content = System.IO.File.ReadAllText(fullPath);
                var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
                htmlContent = Markdown.ToHtml(content, pipeline);
            }
            else
            {
                return NotFound();
            }

            ViewData["GuideContent"] = htmlContent;
            return View();
        }

        private (IEnumerable<string>, IEnumerable<string>) GetDirectoriesAndFiles(string fullPath = null)
        {
            fullPath ??= Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Guides");

            var directories = Directory.GetDirectories(fullPath)
                .Select(Path.GetFileName)
                .Where(dir => !string.IsNullOrEmpty(dir));

            var files = Directory.GetFiles(fullPath)
                .Select(Path.GetFileName)
                .Where(file => !string.IsNullOrEmpty(file));

            return (directories, files);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}