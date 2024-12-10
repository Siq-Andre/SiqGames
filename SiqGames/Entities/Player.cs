namespace SiqGames.Entities
{
    public class Player:Entity<int>
    {
        public string Nickname { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Dlc> Dlcs { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public DateOnly BirthDate { get; set; }
        public virtual ICollection<PlayerPlayer> Player1Friends { get; set; }
        public virtual ICollection<PlayerPlayer> Player2Friends { get; set; }
        public virtual ICollection<Studio> Studios { get; set; }

        public Player()
        {
            Games = new List<Game>();
            Sales = new List<Sale>();
            Player1Friends = new List<PlayerPlayer>();
            Player2Friends = new List<PlayerPlayer>();
            Studios = new List<Studio>();

        }
    }
}
