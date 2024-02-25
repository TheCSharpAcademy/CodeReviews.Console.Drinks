using Newtonsoft.Json;
namespace DrinksConsoleApp.DataModel;

public record class Drink(
    [JsonProperty(PropertyName = "strDrink")] string Name,
    [JsonProperty(PropertyName = "idDrink")] int Id);

