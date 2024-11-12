namespace SiqGames.Entities
{
    public class Sale: Entity<int>
    {
        public int SaleId { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int GamePriceId { get; set; }
        public GamePrice GamePrice { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
