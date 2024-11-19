namespace SiqGames.Entities
{
    public class Genre : Entity<int>
    {
        public string GenreName { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
