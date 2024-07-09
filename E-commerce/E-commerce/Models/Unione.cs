namespace E_commerce.Models
{
    public class Unione
    {
        public int IDUnione { get; set; }
        public int CarrelloID { get; set; }
        public int ProdottoID { get; set; }
        public int Quantita { get; set; }
        public decimal PrezzoUnitario { get; set; }
        public DateTime? DataAggiunta { get; set; }

    }
}
