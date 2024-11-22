namespace SiqGames.Entities
{
    public class Game: Entity<int>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<Dlc> Dlcs { get; set; }
        public Studio Studio { get; set; }
        public string Description { get; set; }
    }
}
