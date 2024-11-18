namespace SiqGames.Entities
{
    public class Sale: Entity<int>
    {
        public int GamePriceId { get; set; }
        public GamePrice GamePrice { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
