namespace SiqGames.Entities
{
    public class Player:Entity<int>
    {
        public string Nickname { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<PlayerGame>? PlayerGames { get; set; }
        public ICollection<Sale>? Sales { get; set; }
        public DateOnly BirthDate { get; set; }
        public List<PlayerFriend>? Player1Friends { get; set; }
        public List<PlayerFriend>? Player2Friends { get; set; }
        public List<PlayerStudio>? PlayerStudios { get; set; }
    }
}
