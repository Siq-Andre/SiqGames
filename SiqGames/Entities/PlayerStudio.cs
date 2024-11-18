namespace SiqGames.Entities
{
    public class PlayerStudio: Entity<int>
    {
        public int PlayerId { get; set; }
        public int StudioId { get; set; }
        public Player Player { get; set; }
        public Studio Studio { get; set; }
    }
}
