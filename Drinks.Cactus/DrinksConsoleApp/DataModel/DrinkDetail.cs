using Newtonsoft.Json;
namespace DrinksConsoleApp.DataModel;

public record class DrinkDetail(
    [JsonProperty(PropertyName = "strDrink")] string Name,
    [JsonProperty(PropertyName = "idDrink")] string Id,
    [JsonProperty(PropertyName = "strCategory")] string Category,
    [JsonProperty(PropertyName = "strInstructions")] string Instruction
    );
