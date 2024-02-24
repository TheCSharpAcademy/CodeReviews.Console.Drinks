using Newtonsoft.Json;
namespace DrinksConsoleApp;

public record class Drink(
    [JsonProperty(PropertyName = "strDrink")] string Name,
    [JsonProperty(PropertyName = "idDrink")] string Id);

