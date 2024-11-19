namespace SiqGames.Entities
{
    public class Game: Entity<int>
    {
        public string GameName { get; set; }
        public GamePrice GamePrices { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<PlayerGame> PlayerGames { get; set; }
        public Studio Studio { get; set; }
        public string Description { get; set; }
    }
}
