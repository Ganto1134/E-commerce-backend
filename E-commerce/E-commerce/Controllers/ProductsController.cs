using Microsoft.AspNetCore.Mvc;
using E_commerce.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace E_commerce.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Prodotto> products = new List<Prodotto>
        {

        };

        public IActionResult Prodotti()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.Find(p => p.IDProdotto == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }



        // Aggiungi metodi per la gestione del carrello e dell'amministrazione
    }
}
