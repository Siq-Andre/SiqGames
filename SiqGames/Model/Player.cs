namespace SiqGames.Model
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Nickname { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
