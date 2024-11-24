using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class DrinksInCategoryList
{
    [JsonProperty("drinks")]
    public DrinkInCategory[]? Drinks { get; set; }
}

public class DrinkInCategory
{
    [JsonProperty("strDrink")]
    public string? DrinkName { get; set; }

    [JsonProperty("idDrink")]
    public string? DrinkId {  get; set; } 
}