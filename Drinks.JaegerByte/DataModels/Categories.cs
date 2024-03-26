using Newtonsoft.Json;
namespace Drinks.JaegerByte.DataModels
{
    public class Categories
    {
        [JsonProperty("drinks")]
        public List<Category> CategoryList { get; set; }
    }
    public class Category
    {
        [JsonProperty("strCategory")]
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }


}
