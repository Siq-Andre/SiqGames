namespace SiqGames.Entities
{
    public class Sale: Entity<int>
    {
        public virtual Game? Game { get; set; }
        public virtual Dlc? Dlc { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
