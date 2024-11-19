namespace SiqGames.Entities
{
    public class Sale: Entity<int>
    {
        public Game Game { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
