using System.Text.Json.Serialization;

namespace sadklouds.Drinks.Models
{
    public class Categories
    {
        [JsonPropertyName("drinks")]
        public List<Category> CategoryList { get; set; }
    }

}
