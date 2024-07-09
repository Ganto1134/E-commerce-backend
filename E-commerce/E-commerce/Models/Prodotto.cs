namespace E_commerce.Models
{
    public class Prodotto
    {
        public int IDProdotto { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }
        public string Categoria { get; set; }
        public DateTime? DataInserimento { get; set; }
    }
}
