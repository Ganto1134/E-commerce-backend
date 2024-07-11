using E_commerce.Models;
using System.Data.Common;
using System.Data.SqlClient;


namespace E_commerce.Services
{
    public class CarrelloService : SqlServiceBase
    {
        public CarrelloService(IConfiguration config) : base(config)
        {
        }

        // Funzione per ottenere tutti i prodotti nel carrello
        public List<Unione> OttieniProdottiNelCarrello()
        {
            var prodottiNelCarrello = new List<Unione>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = GetCommand("SELECT * FROM Unione INNER JOIN Prodotti ON Unione.ProdottoID = Prodotti.IDProdotto");
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        prodottiNelCarrello.Add(new Unione
                        {
                            IDUnione = reader.GetInt32(reader.GetOrdinal("IDUnione")),
                            CarrelloID = reader.GetInt32(reader.GetOrdinal("CarrelloID")),
                            ProdottoID = reader.GetInt32(reader.GetOrdinal("ProdottoID")),
                            Quantita = reader.GetInt32(reader.GetOrdinal("Quantita")),
                            PrezzoUnitario = reader.GetDecimal(reader.GetOrdinal("PrezzoUnitario")),
                            DataAggiunta = reader.GetDateTime(reader.GetOrdinal("DataAggiunta"))
                        });
                    }
                }
            }
            return prodottiNelCarrello;
        }

        // Funzione per aggiungere un prodotto al carrello
        public void AggiungiProdottoAlCarrello(int prodottoId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                // First command: Get product price
                using (var command = GetCommand("SELECT Prezzo FROM Prodotti WHERE IDProdotto = @ProdottoID")) //                         

                {
                    command.Parameters.Add(new SqlParameter("@ProdottoID", prodottoId));
                    var prezzo = (decimal)command.ExecuteScalar();

                    // Second command: Check if product is already in the cart
                    command.CommandText = "SELECT * FROM Unione WHERE CarrelloID = 1 AND ProdottoID = @ProdottoID";
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@ProdottoID", prodottoId));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Update quantity if product is already in the cart
                            var quantita = reader.GetInt32(reader.GetOrdinal("Quantita")) + 1;
                            command.CommandText = "UPDATE Unione SET Quantita = @Quantita WHERE CarrelloID = 1 AND ProdottoID = @ProdottoID";
                            command.Parameters.Clear();
                            command.Parameters.Add(new SqlParameter("@Quantita", quantita));
                            command.Parameters.Add(new SqlParameter("@ProdottoID", prodottoId));
                        }
                        else
                        {
                            // Insert new product into the cart
                            command.CommandText = "INSERT INTO Unione (CarrelloID, ProdottoID, Quantita, PrezzoUnitario) VALUES (1, @ProdottoID, 1, @PrezzoUnitario)";
                            command.Parameters.Clear();
                            command.Parameters.Add(new SqlParameter("@ProdottoID", prodottoId));
                            command.Parameters.Add(new SqlParameter("@PrezzoUnitario", prezzo));
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }


        // Funzione per rimuovere un prodotto dal carrello
        public void RimuoviProdottoDalCarrello(int prodottoId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = GetCommand("DELETE FROM Unione WHERE CarrelloID = 1 AND ProdottoID = @ProdottoID");
                command.Parameters.Add(new SqlParameter("@ProdottoID", prodottoId));
                command.ExecuteNonQuery();
            }
        }
    }
}
