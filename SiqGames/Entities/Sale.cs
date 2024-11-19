namespace SiqGames.Entities
{
    public class Sale: Entity<int>
    {
        public int GamePriceId { get; set; }
        public Price GamePrice { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
