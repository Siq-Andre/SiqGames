namespace SiqGames.Model
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public Studio Studio { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public bool isActive { get; set; }
    }
}
