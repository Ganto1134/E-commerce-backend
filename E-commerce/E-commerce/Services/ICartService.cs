using E_commerce.Models;
using System.Data.Common;

namespace E_commerce.Services
{
    public interface ICartService
    {
        public void AggiungiAlCarrello(Cart cartItem);
        public Cart Create(DbDataReader reader);

        public IEnumerable<Cart> GetProductsCart();


    }
}
