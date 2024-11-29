namespace SiqGames.Entities
{
    public class Player:Entity<int>
    {
        public string Nickname { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public DateOnly BirthDate { get; set; }
        public virtual ICollection<PlayerPlayer> Player1Friends { get; set; }
        public virtual ICollection<PlayerPlayer> Player2Friends { get; set; }
        public virtual ICollection<Studio> Studios { get; set; }
    }
}
