using Newtonsoft.Json;

namespace DrinksInfo.Models
{
    public class Category : IDrinksJson
    {
        public string StrCategory { get; set; }

        public string GetName()
        {
            return StrCategory;
        }

        public void ChangeName(string name)
        {
            StrCategory = name;
        }
    }

    public class Categories
    {
        [JsonProperty("drinks")]
        public List<Category> CategoriesList { get; set; }
    }
}
