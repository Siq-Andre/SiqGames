namespace SiqGames.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public ICollection<GamePrice>? GamePrices { get; set; }
        public List<GameGenre>? GameGenres { get; set; }
        public List<PlayerGame>? PlayerGames { get; set; }
        public int StudioId { get; set; }
        public Studio Studio { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public bool IsActive { get; set; }
    }
}
