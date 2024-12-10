namespace SiqGames.Entities
{
    public class Dlc: Entity<int>
    {
        public string Title {  get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
