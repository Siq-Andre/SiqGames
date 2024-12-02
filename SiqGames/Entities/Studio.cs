namespace SiqGames.Entities
{
    public class Studio: Entity<int>
    {
        public string StudioName { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
