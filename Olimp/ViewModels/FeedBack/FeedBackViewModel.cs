using Olimp.Models;
using Olimp.ViewModels.StoreWarehouse;

namespace Olimp.ViewModels.FeedBack
{
    public class FeedBackViewModel
    {
        public int Id { get; set; }
        public int Star { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public StoreWarehouseViewModel StoreWarehouse { get; set; }
        public int StoreWarehouseId { get; set; }
    }
}