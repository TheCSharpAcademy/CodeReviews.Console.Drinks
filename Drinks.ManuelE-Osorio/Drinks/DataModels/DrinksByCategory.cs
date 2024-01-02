using System.Text.Json.Serialization;

namespace DrinksProgram;
public class DrinksByCategoryJSON
{
    [JsonPropertyName("drinks")] public List<DrinksByCategory> Drinks { get; set; } = [];
}

public class DrinksByCategory
{
    public string Selection { get; set; } = "";
    [JsonPropertyName("idDrink")] public string ID { get; set; } = "0";
    [JsonPropertyName("strDrink")] public string DrinkName { get; set; } = "";
}

