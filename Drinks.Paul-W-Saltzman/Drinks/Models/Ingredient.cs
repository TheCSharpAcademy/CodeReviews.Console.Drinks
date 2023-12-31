using Newtonsoft.Json;

namespace drinks_info.Models
{
    public class Ingredient
    {
        public string strIngredient1 { get; set; }
    }

    public class Ingredients
    {
        [JsonProperty("drinks")]

        public List<Ingredient> IngredientsList { get; set; }
        
    }
}

