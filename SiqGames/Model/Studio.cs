namespace SiqGames.Model
{
    public class Studio
    {
        public int StudioId { get; set; }
        public string StudioName { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public bool IsActive { get; set; }
    }
}
