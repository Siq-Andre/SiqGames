namespace SiqGames.Entities
{
    public class GameGenre: Entity<int>
    {
        public int GenreId { get; set; }
        public int GameId { get; set; }
        public Genre Genre { get; set; }
        public Game Game { get; set; }
    }
}
