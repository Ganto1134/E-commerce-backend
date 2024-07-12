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
        private readonly CarrelloService _carrelloService;


        public HomeController(
            ILogger<HomeController> logger,
            IConfiguration config,
            IProdottoService prodottoService,
            CarrelloService carrelloService
            )
        {
            _logger = logger;
            _config = config;
            _prodottoService = prodottoService;
            _carrelloService = carrelloService;

        }

        public IActionResult Index()
        {
            return View(_prodottoService.GetProducts());
        }

        //carrello 
        public IActionResult Cart()
        {
            var cartItems = _carrelloService.OttieniProdottiNelCarrello();
            return View(cartItems);
        }

        public IActionResult AddToCart(int id)
        {
            _carrelloService.AggiungiProdottoAlCarrello(id);
            return RedirectToAction("Cart");
        }

        public IActionResult Details(int id)
        {
            return View(_prodottoService.GetProdotto(id));
        }

        public IActionResult Privacy()
        public IActionResult RemoveFromCart(int id)
        {
            _carrelloService.RimuoviProdottoDalCarrello(id);
            return RedirectToAction("Cart");
        }

        // Dettagli prodotto
        public IActionResult Dettagli(int id)
        {
            return View(_prodottoService.GetProdotto(id));
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
