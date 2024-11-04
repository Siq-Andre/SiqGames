namespace SiqGames.Model
{
    public class PlayerFriend
    {
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public bool IsActive { get; set; }
    }
}
