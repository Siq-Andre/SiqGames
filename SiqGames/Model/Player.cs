namespace SiqGames.Model
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Nickname { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<PlayerGame>? PlayerGames { get; set; }
        public ICollection<Sale>? Sales { get; set; }
        public DateOnly BirthDate { get; set; }
        public List<PlayerFriend>? Player1Friends { get; set; }
        public List<PlayerFriend>? Player2Friends { get; set; }
        public List<PlayerStudio>? PlayerStudios { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public bool IsActive { get; set; }
    }
}
