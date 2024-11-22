using SiqGames.Entities;

namespace SiqGames.ViewModels
{
    public class PlayerRequestViewModel
    {
        public string Nickname { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
