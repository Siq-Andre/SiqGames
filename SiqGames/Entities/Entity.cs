namespace SiqGames.Entities
{
    public class Entity<T>:IAuditable
    {
        public T Id { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UserModified { get; set; }
        public bool IsActive { get; set; }
    }
}
