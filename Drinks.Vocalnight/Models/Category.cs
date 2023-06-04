using Newtonsoft.Json;

namespace DrinksInfo.Models
{
    public class Category : IDrinksJson
    {
        public string strCategory { get; set; }

        public string GetName()
        {
            return strCategory;
        }

        public void ChangeName(string name)
        {
            strCategory = name;
        }
    }

    public class Categories
    {
        [JsonProperty("drinks")]
        public List<Category> CategoriesList { get; set; }
    }
}
