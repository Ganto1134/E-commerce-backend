using System;
using System.Data.Common;
using System.Data.SqlClient;
using E_commerce.Models;

namespace E_commerce.Services
{
    public class CartService: ICartService
    {
        private readonly string _connectionString;

        public CartService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AggiungiAlCarrello(Cart cartItem)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                var query = "INSERT INTO Cart (IDProdottoFK, Quantita, NomeFK, PrezzoFK) VALUES (@IDProdottoFK, @Quantita, @NomeFK, @PrezzoFK)";
                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@IDProdottoFK", cartItem.IDProdottoFK));
                cmd.Parameters.Add(new SqlParameter("@Quantita", cartItem.Quantita));
                cmd.Parameters.Add(new SqlParameter("@PrezzoFK", cartItem.PrezzoFK));
                cmd.Parameters.Add(new SqlParameter("@NomeFK", cartItem.NomeFK));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("AggiungiAlCarrello fallito", ex);
            }
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        private SqlCommand GetCommand(string commandText, SqlConnection connection)
        {
            return new SqlCommand(commandText, connection);
        }

        public Cart Create(DbDataReader reader) => new Cart
        {
            IDCart = reader.GetInt32(0),
            IDProdottoFK=reader.GetInt32(1),
            Quantita = reader.GetInt32(2),
            NomeFK = reader.GetString(3),
            PrezzoFK = reader.GetDecimal(4),
           
        };

        public IEnumerable<Cart> GetProductsCart()
        {
            try
            {
                using var conn = GetConnection();
                var cmd = GetCommand("SELECT * FROM Cart", conn);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                var prodotti = new List<Cart>();
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
    }
}
