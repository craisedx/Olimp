namespace Olimp.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public int Star { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public StoreWarehouse StoreWarehouse { get; set; }
        public int StoreWarehouseId { get; set; }
    }
}