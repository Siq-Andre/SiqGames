namespace SiqGames.Model
{
    public class Sale
    {
        public int SaleId { get; set; }
        public Player Player { get; set; }
        public GamePrice GamePrice { get; set; }
        public double FinalPrice { get; set; }
    }
}
