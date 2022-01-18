using System.Collections.Generic;
using Newtonsoft.Json;

namespace Olimp.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public List<BasketStoreWarehouse> StoreWarehouses { get; set; }
    }
}