using System.Collections.Generic;
using Newtonsoft.Json;

namespace Olimp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<StoreWarehouse> StoreWarehouses { get; set; } 
    }
}