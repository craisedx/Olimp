using System.Collections.Generic;
using Newtonsoft.Json;

namespace Olimp.Models
{
    public class StoreWarehouse
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        [JsonIgnore]
        public List<BasketStoreWarehouse> Baskets { get; set; }
        [JsonIgnore]
        public List<OrderStoreWarehouses> Orders { get; set; }
    }
}