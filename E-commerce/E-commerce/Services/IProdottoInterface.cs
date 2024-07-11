using E_commerce.Models;
using System.Collections.Generic;

namespace E_commerce.Services
{
    public interface IProdottoService
    {
        IEnumerable<Prodotto> GetProducts();
        Prodotto GetProdotto(int id);
        void AggiungiProdotto(Prodotto prodotto);
        void AggiornaProdotto(Prodotto prodotto);
        void EliminaProdotto(int id);
    }
}
