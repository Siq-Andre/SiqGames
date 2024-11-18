namespace SiqGames.Entities
{
    public class Genre : Entity<int>
    {
        public string GenreName { get; set; }
        public List<GameGenre>? GameGenres { get; set; }
    }
}
