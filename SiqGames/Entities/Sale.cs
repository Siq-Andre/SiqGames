namespace SiqGames.Entities
{
    public class Sale: Entity<int>
    {
        public Game? Game { get; set; }
        public Dlc? Dlc { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
