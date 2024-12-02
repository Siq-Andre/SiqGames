namespace SiqGames.Entities
{
    public class PlayerPlayer : Entity<int>
    {
        public virtual Player Player1 { get; set; }
        public virtual Player Player2 { get; set; }
    }
}
