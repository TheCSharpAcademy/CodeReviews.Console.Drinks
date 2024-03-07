using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class DrinksModel
{
    public List<Drinks> Drinks { get; set; }
}


public class Drinks
{
    [JsonProperty("idDrink")]
    public int Id { get; set; }

    [JsonProperty("strDrink")]
    public string Name { get; set; }

    [JsonProperty("strCategory")]
    public string Category { get; set; }

    [JsonProperty("strInstructions")]
    public string Instructions { get; set; }

    [JsonProperty("strIngredient1")]
    public string Ingredient1 { get; set; }

    [JsonProperty("strIngredient2")]
    public string Ingredient2 { get; set; }

    [JsonProperty("strIngredient3")]
    public string Ingredient3 { get; set; }

    [JsonProperty("strIngredient4")]
    public string Ingredient4 { get; set; }

    [JsonProperty("strIngredient5")]
    public string Ingredient5 { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
