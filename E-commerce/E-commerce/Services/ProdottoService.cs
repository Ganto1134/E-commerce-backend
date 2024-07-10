using System.Collections.Generic;
using System.Data.Common;
using E_commerce.Models;
using E_commerce.Services;
using System.Data.SqlClient;


namespace E_commerce.Services
{
    public class ProdottoService : IProdottoService
    {
        private readonly DbConnection _connection;
        public ProdottoService() {
            _connection = new SqlConnection();
        }
        public List<Prodotto> GetProducts()
        {
            throw new System.NotImplementedException();
        }

        public void AggiungiProdotto(Prodotto prodotto)
        {
            throw new System.NotImplementedException();
        }

        public void AggiornaProdotto(Prodotto prodotto)
        {
            throw new System.NotImplementedException();
        }

        public void EliminaProdotto(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
