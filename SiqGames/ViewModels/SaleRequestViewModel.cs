namespace SiqGames.ViewModels
{
    public class SaleRequestViewModel
    {
        public int? GameId { get; set; }
        public int? DlcId { get; set; }
        public decimal FinalPrice { get; set; }
        public int PlayerId { get; set; }
    }
}
