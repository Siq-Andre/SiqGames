namespace SiqGames.Entities
{
    public class Player:Entity<int>
    {
        public string Nickname { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public ICollection<PlayerGame>? PlayerGames { get; set; }
        public ICollection<Sale>? Sales { get; set; }
        public DateOnly BirthDate { get; set; }
        public ICollection<PlayerFriend>? Player1Friends { get; set; }
        public ICollection<PlayerFriend>? Player2Friends { get; set; }
        public ICollection<PlayerStudio>? PlayerStudios { get; set; }
    }
}
