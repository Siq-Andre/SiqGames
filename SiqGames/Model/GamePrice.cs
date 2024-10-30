namespace SiqGames.Model
{
    public class GamePrice
    {
        public int GamePriceID { get; set; }
        public double Price { get; set; }
        public Game Game { get; set; }
        public bool IsActive { get; set; }
    }
}
