using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DependencyInjection.Models;

namespace DependencyInjection.Controllers
{
    public class SettingsController : Controller
    {
        private readonly Myjson _settings;
        public SettingsController(IOptions<Myjson> settingsOptions)
        {
            _settings = settingsOptions.Value;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = _settings.Title;
            ViewData["Version"] = _settings.Version;
            return View();
        }

        public IActionResult Show()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
