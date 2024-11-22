namespace SiqGames.Entities
{
    public class Player:Entity<int>
    {
        public string Nickname { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public DateOnly BirthDate { get; set; }
        public ICollection<PlayerPlayer> Player1Friends { get; set; }
        public ICollection<PlayerPlayer> Player2Friends { get; set; }
        public ICollection<Studio> Studios { get; set; }
    }
}
