using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Olimp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public int FinalPrice { get; set; }
        [JsonIgnore]
        public List<OrderStoreWarehouses> StoreWarehouses { get; set; }
    }
}