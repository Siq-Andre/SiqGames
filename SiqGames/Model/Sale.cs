namespace SiqGames.Model
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int GamePriceId { get; set; }
        public GamePrice GamePrice { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public bool IsActive { get; set; }
    }
}
