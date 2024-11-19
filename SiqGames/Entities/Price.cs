namespace SiqGames.Entities
{
    public class Price: Entity<int>
    {
        public decimal Cost { get; set; }
        public ICollection<Sale>? Sales { get; set; }
    }
}
