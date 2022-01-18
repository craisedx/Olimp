namespace Olimp.Models
{
    public class BasketStoreWarehouse
    {
        public int Id { get; set; }
        public StoreWarehouse StoreWarehouse { get; set; }
        public int StoreWarehouseId { get; set; }
        public Basket Basket { get; set; }
        public int BasketId { get; set; }
        public int Quantity { get; set; }
    }
}