using E_commerce.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace E_commerce.Services
{
    public class ProdottoService : IProdottoService
    {
        private readonly string _connectionString;

        public ProdottoService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        private SqlCommand GetCommand(string commandText, SqlConnection connection)
        {
            return new SqlCommand(commandText, connection);
        }

        public IEnumerable<Prodotto> GetProducts()
        {
            try
            {
                using var conn = GetConnection();
                var cmd = GetCommand("SELECT * FROM Prodotti", conn);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                var prodotti = new List<Prodotto>();
                while (reader.Read())
                {
                    prodotti.Add(Create(reader));
                }
                return prodotti;
            }
            catch (Exception ex)
            {
                throw new Exception("GetProducts fallito", ex);
            }
        }

        public Prodotto GetProdotto(int id)
        {
            try
            {
                /*var cmd = GetCommand("SELECT *  FROM Prodotti WHERE IDProdotto = @id");
                cmd.Parameters.Add(new SqlParameter("@id", id));*/
                using var conn = GetConnection();
                var cmd = GetCommand("SELECT * FROM Prodotti WHERE IDProdotto = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                    return Create(reader);
                throw new Exception("Non trovato");
            }
            catch (Exception ex)
            {
                throw new Exception("GetProdotto fallito", ex);
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
                using var conn = GetConnection();
                var cmd = GetCommand("INSERT INTO Prodotti (Nome, Descrizione, Prezzo, Categoria, DataInserimento, ImmagineLink) VALUES (@Nome, @Descrizione, @Prezzo, @Categoria, @DataInserimento, @ImmagineLink)", conn);
                cmd.Parameters.Add(new SqlParameter("@Nome", prodotto.Nome));
                cmd.Parameters.Add(new SqlParameter("@Descrizione", prodotto.Descrizione));
                cmd.Parameters.Add(new SqlParameter("@Prezzo", prodotto.Prezzo));
                cmd.Parameters.Add(new SqlParameter("@Categoria", prodotto.Categoria));
                cmd.Parameters.Add(new SqlParameter("@DataInserimento", prodotto.DataInserimento));
                cmd.Parameters.Add(new SqlParameter("@ImmagineLink", prodotto.ImmagineLink));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("AggiuntaProdotto fallito", ex);
            }
        }

        public void AggiornaProdotto(Prodotto prodotto)
        {
            try
            {
                using var conn = GetConnection();
                var query = "UPDATE Prodotti SET Nome = @Nome, Descrizione = @Descrizione, Prezzo = @Prezzo, Categoria = @Categoria, DataInserimento = @DataInserimento, ImmagineLink = @ImmagineLink WHERE IDProdotto = @IDProdotto";
                var cmd = GetCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@IDProdotto", prodotto.IDProdotto));
                cmd.Parameters.Add(new SqlParameter("@Nome", prodotto.Nome));
                cmd.Parameters.Add(new SqlParameter("@Descrizione", prodotto.Descrizione));
                cmd.Parameters.Add(new SqlParameter("@Prezzo", prodotto.Prezzo));
                cmd.Parameters.Add(new SqlParameter("@Categoria", prodotto.Categoria));
                cmd.Parameters.Add(new SqlParameter("@DataInserimento", prodotto.DataInserimento));
                cmd.Parameters.Add(new SqlParameter("@ImmagineLink", prodotto.ImmagineLink));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("AggiornaProdotto fallito", ex);
            }
        }

        public void EliminaProdotto(int id)
        {
            try
            {
                using var conn = GetConnection();
                var query = "DELETE FROM Prodotti WHERE IDProdotto = @IDProdotto";
                var cmd = GetCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@IDProdotto", id));
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result != 1) throw new Exception("Comando fallito");
            }
            catch (Exception ex)
            {
                throw new Exception("EliminaProdotto fallito", ex);
            }
        }
    }
}
