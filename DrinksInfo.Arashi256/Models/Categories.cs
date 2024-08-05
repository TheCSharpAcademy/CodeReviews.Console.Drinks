using Newtonsoft.Json;

namespace DrinksInfo.Arashi256.Models
{
    internal class Categories
    {
        [JsonProperty("drinks")]
        public List<Category> CategoriesList { get; set; }
    }
}
