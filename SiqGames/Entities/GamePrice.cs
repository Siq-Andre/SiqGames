namespace SiqGames.Entities
{
    public class GamePrice: Entity<int>
    {
        public int GamePriceID { get; set; }
        public decimal Price { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public ICollection<Sale>? Sales { get; set; }
    }
}
