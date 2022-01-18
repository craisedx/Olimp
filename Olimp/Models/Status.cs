using System.Collections.Generic;
using Newtonsoft.Json;

namespace Olimp.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; }
        [JsonIgnore]
        public List<Order> Orders { get; set; }
    }
}