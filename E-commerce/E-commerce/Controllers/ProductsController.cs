using Microsoft.AspNetCore.Mvc;
using E_commerce.Models;
using E_commerce.Services;
using System;

namespace E_commerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProdottoService _prodottoService;

        public ProductsController(IProdottoService prodottoService)
        {
            _prodottoService = prodottoService;
        }

        public IActionResult Index()
        {
            var prodotti = _prodottoService.GetProducts();
            return View(prodotti);
        }

        public IActionResult Details(int id)
        {
            var product = _prodottoService.GetProdotto(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult AggiungiProdotto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AggiungiProdotto(Prodotto prodotto)
        {
            if (ModelState.IsValid)
            {
                prodotto.DataInserimento = DateTime.Now;
                _prodottoService.AggiungiProdotto(prodotto);
                return RedirectToAction("Index");
            }
            return View(prodotto);
        }

        [HttpPost]
        public IActionResult EliminaProdotto(int id)
        {
            try
            {
                _prodottoService.EliminaProdotto(id);
                return RedirectToAction("Admin", "Home");
            }
            catch (Exception ex)
            {
                // Gestione degli errori, mostrare un messaggio di errore
                return View("Error", new { message = ex.Message });
            }
        }
    }
}