namespace E_commerce.Models
{
    public class Cart
    {
        public int IDCart { get; set; }
        public int IDProdottoFK { get; set; }
        public int Quantita { get; set; }

        public string NomeFK { get; set; }

        public decimal PrezzoFK { get; set; }

        public decimal Total => Quantita * PrezzoFK;
    }
}
