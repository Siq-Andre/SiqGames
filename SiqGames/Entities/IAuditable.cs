namespace SiqGames.Entities
{
    public interface IAuditable
    {
        public DateTime DateTimeCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UserModified { get; set; }
        public bool IsActive { get; set; }
    }
}
