//using E_commerce.Models;
//using System.Data.Common;

//namespace E_commerce.Services
//{
//    public interface IProdottoService
//    {
//        public IEnumerable<Prodotto> GetProducts(int id);
//        public void AggiungiProdotto(Prodotto prodotto);
//        public void AggiornaProdotto(Prodotto prodotto);
//        public void EliminaProdotto(int id);
//    }
//}
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
