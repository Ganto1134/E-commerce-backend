using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using E_commerce.Services;

namespace E_commerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly IProdottoService _prodottoService;

        public HomeController(
            ILogger<HomeController> logger,
            IConfiguration config,
            IProdottoService prodottoService
            )
        {
            _logger = logger;
            _config = config;
            _prodottoService = prodottoService;
        }

        public IActionResult Index()
        {
            return View(_prodottoService.GetProducts());

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View(_prodottoService.GetProducts());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
