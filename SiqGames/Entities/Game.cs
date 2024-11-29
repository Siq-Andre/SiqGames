namespace SiqGames.Entities
{
    public class Game: Entity<int>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Dlc> Dlcs { get; set; }
        public virtual Studio Studio { get; set; }
        public string Description { get; set; }

        public Game()
        {
            Genres = new List<Genre>();
            Players = new List<Player>();
            Dlcs = new List<Dlc>();
        }
    }

}
