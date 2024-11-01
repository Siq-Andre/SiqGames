namespace SiqGames.Model
{
    public class PlayerStudio
    {
        public int PlayerId { get; set; }
        public int StudioId { get; set; }
        public Player Player { get; set; }
        public Studio Studio { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public bool IsActive { get; set; }
    }
}
