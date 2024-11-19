namespace SiqGames.Entities
{
    public class Studio: Entity<int>
    {
        public string StudioName { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
