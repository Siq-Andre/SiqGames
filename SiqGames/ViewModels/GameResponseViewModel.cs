namespace SiqGames.ViewModels
{
    public class GameResponseViewModel
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int StudioId { get; set; }
        public string Description { get; set; }

        public DateTime DateTimeCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UserModified { get; set; }
        public bool IsActive { get; set; }
    }
}
