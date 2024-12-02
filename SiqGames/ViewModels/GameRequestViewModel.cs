using SiqGames.Entities;

namespace SiqGames.ViewModels
{
    public class GameRequestViewModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        //public Studio Studio { get; set; }
        public int StudioId { get; set; }
        public string Description { get; set; }
    }
}
