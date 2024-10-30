namespace SiqGames.Model
{
    public class GamePrice
    {
        public int GamePriceID { get; set; }
        public double Price { get; set; }
        public Game Game { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public bool IsActive { get; set; }
    }
}
