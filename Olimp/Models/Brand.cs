using System.Collections.Generic;
using Newtonsoft.Json;

namespace Olimp.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string ProductBrand { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}