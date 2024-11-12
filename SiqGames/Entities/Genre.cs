namespace SiqGames.Entities
{
    public class Genre : Entity<int>
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public List<GameGenre>? GameGenres { get; set; }
    }
}
