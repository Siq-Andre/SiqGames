namespace SiqGames.Model
{
    public class GameGenre
    {
        public int GenreId { get; set; }
        public int GameId { get; set; }
        public Genre Genre { get; set; }
        public Game Game { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public bool IsActive { get; set; }
    }
}
