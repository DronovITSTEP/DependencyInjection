using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DependencyInjection.Repositories.Interfaces;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {  

        private IRepository _repository;
        //private ProductSum productSum;

        public HomeController(IRepository repository 
            /*ProductSum pSum*/)
        {
            _repository = repository;
            //productSum = pSum;
        }

        public IActionResult Index([FromServices] ProductSum productSum)
        {
            //ViewBag.Total = productSum.Total;

            ViewBag.HomeControllerGuid = _repository.ToString();
            ViewBag.TotalGuid = productSum.Repository.ToString();

            return View(_repository.Products);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}