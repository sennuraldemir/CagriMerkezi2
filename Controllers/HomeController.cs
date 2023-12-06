using CagriMerkezi2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CagriMerkezi2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Index";
            return View();
        }

        public ActionResult VatandasBasvuruMerkezi()
        {
            return View();
        }

        public ActionResult Iletisim()
        {
            return View();
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