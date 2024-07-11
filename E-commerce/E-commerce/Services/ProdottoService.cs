using System.Data.Common;
using E_commerce.Models;
using E_commerce.Services;
using System.Data.SqlClient;

namespace E_commerce.Services
{
    public class ProdottoService : SqlServiceBase , IProdottoService

        
    {

        public ProdottoService(IConfiguration config): base (config) {
            
        }
        public IEnumerable<Prodotto> GetProducts() //get da TUTTI i prodotti
        {
            try
            {
                var cmd = GetCommand("SELECT * FROM Prodotti");
                using var conn = GetConnection();
                conn.Open();
                var reader = cmd.ExecuteReader();
                var prodotti = new List<Prodotto>();
                while (reader.Read())
                {
                    prodotti.Add(Create(reader));
                }
                return prodotti;
            }
            catch
            {
                throw new Exception("GetProductS  fallito");
            }
        }

        public Prodotto GetProdotto(int id) //GET prodottosingolo.ID
        {
            try
            {
                var cmd = GetCommand("SELECT *  FROM Prodotti WHERE IDProdotto = @id");
                cmd.Parameters.Add(new SqlParameter("@id", id));
                using var conn = GetConnection();
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                    return Create(reader);
                throw new Exception("Non trovato");
            }
            catch
            {
                throw;
            }
        }

        public Prodotto Create(DbDataReader reader) => new Prodotto
        {
            IDProdotto = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Descrizione = reader.GetString(2),
            Prezzo = reader.GetDecimal(3),
            Categoria = reader.GetString(4),
            DataInserimento = reader.GetDateTime(5),
            ImmagineLink = reader.GetString(6)
        };




        public void AggiungiProdotto(Prodotto prodotto)
        {
            try
            {
                var cmd = GetCommand("INSERT INTO Prodotti (Nome, Descrizione, Prezzo, Categoria, DataInserimento, ImmagineLink) VALUES (@Nome, @Descrizione, @Prezzo, @Categoria, @DataInserimento, @ImmagineLink)");
                cmd.Parameters.Add(new SqlParameter("@Nome", prodotto.Nome));
                cmd.Parameters.Add(new SqlParameter("@Descrizione", prodotto.Descrizione));
                cmd.Parameters.Add(new SqlParameter("@Prezzo", prodotto.Prezzo));
                cmd.Parameters.Add(new SqlParameter("@Categoria", prodotto.Categoria));
                cmd.Parameters.Add(new SqlParameter("@DataInserimento", prodotto.DataInserimento));
                cmd.Parameters.Add(new SqlParameter("@ImmagineLink", prodotto.ImmagineLink));
                using var conn = GetConnection();
                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("AggiuntaProdotto fallito");
            }
        }

    public void AggiornaProdotto(Prodotto prodotto)
    {
        try
        {
            var query = "UPDATE Prodotti SET Nome = @Nome, Descrizione = @Descrizione, Prezzo = @Prezzo, Categoria = @Categoria, DataInserimento = @DataInserimento, ImmagineLink = @ImmagineLink WHERE IDProdotto = @IDProdotto";
            var cmd = GetCommand(query);
            cmd.Parameters.Add(new SqlParameter("@IDProdotto", prodotto.IDProdotto));
            cmd.Parameters.Add(new SqlParameter("@Nome", prodotto.Nome));
            cmd.Parameters.Add(new SqlParameter("@Descrizione", prodotto.Descrizione));
            cmd.Parameters.Add(new SqlParameter("@Prezzo", prodotto.Prezzo));
            cmd.Parameters.Add(new SqlParameter("@Categoria", prodotto.Categoria));
            cmd.Parameters.Add(new SqlParameter("@DataInserimento", prodotto.DataInserimento));
            cmd.Parameters.Add(new SqlParameter("@ImmagineLink", prodotto.ImmagineLink));
            using var conn = GetConnection();
            conn.Open();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
        }
        catch
        {
            throw new Exception("AggiornaProdotto fallito");
        }
    }

    public void EliminaProdotto(int id)
        {
            var query = "DELETE FROM Prodotto WHERE IDProdotto = @IDProdotto";
            var cmd = GetCommand(query);
            cmd.Parameters.Add(new SqlParameter("@IDProdotto", id));
            using var conn = GetConnection();
            conn.Open();
            int result = cmd.ExecuteNonQuery();
                if (result != 1) throw new Exception("Comando fallito");
            cmd.ExecuteNonQuery();
        }



    }
}
