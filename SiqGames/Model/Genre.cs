namespace SiqGames.Model
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public List<GameGenre> GameGenres { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public bool IsActive { get; set; }
    }
}
