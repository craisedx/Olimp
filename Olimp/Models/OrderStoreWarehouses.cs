namespace Olimp.Models
{
    public class OrderStoreWarehouses
    {
        public int Id { get; set; }
        public StoreWarehouse StoreWarehouse { get; set; }
        public int StoreWarehouseId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}