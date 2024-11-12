namespace SiqGames.Entities
{
    public class PlayerGame: Entity<int>
    {
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public Player Player { get; set; }
        public Game Game { get; set; }
        public TimeOnly TimePlayed { get; set; }
    }
}
