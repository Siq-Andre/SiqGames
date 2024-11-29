namespace SiqGames.Entities
{
    public class PlayerPlayer : Entity<int>
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
    }
}
