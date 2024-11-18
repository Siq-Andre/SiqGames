namespace SiqGames.Entities
{
    public class Studio: Entity<int>
    {
        public int StudioId { get; set; }
        public string StudioName { get; set; }
        public ICollection<Game>? Games { get; set; }
        public List<PlayerStudio>? PlayerStudios { get; set; }
    }
}
