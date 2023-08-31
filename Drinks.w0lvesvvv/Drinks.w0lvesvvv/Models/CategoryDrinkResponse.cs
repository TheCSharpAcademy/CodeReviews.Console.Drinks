using Newtonsoft.Json;

namespace Drinks.w0lvesvvv.Models
{
    public class CategoryDrinkResponse
    {
        [JsonProperty("drinks")]
        public List<CategoryDrink>? ListDrinks { get; set; }
    }

    public class CategoryDrink {
        [JsonProperty("idDrink")]
        public int Drink_id { get; set; }
        [JsonProperty("strDrink")]
        public string? Drink_name { get; set; }
    }
}
