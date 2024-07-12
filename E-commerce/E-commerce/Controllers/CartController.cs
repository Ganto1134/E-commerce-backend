using Microsoft.AspNetCore.Mvc;
using E_commerce.Models;
using E_commerce.Services;

namespace E_commerce.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public IActionResult AggiungiAlCarrello(Cart cartItem)
        {
            if (ModelState.IsValid)
            {
                _cartService.AggiungiAlCarrello(cartItem);
                return RedirectToAction("Index", "Home");
            }
            return View();
            
            
        }

        public IActionResult Carrello()
        {
            return View(_cartService.GetProductsCart());

        }


    }
}
