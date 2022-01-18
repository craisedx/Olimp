using System.Collections.Generic;
using Newtonsoft.Json;

namespace Olimp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string ProductCategory { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}