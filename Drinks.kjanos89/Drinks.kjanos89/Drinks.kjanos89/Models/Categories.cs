using Newtonsoft.Json;

namespace Drinks.kjanos89.Models
{
    public class Categories
    {

        [JsonProperty("drinks")]
        public List<Category> CategoryList { get; set; }

    }
}
