namespace SiqGames.Entities
{
    public class GamePrice: Entity<int>
    {
        public decimal Price { get; set; }
        public ICollection<Sale>? Sales { get; set; }
    }
}
