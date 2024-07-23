using Newtonsoft.Json;

namespace Drinks.kjanos89.Models
{
    public class Category
    {
        [JsonProperty("strCategory")]
        public string CategoryName { get; set; }
    }
}
