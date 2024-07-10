using E_commerce.Models;

namespace E_commerce.Services
{
    public interface IProdottoService
    {
        List<Prodotto> GetProducts();
        void AggiungiProdotto(Prodotto prodotto);
        void AggiornaProdotto(Prodotto prodotto);
        void EliminaProdotto(int id);
    }
}
