using Newtonsoft.Json;

namespace DrinksConsoleApp.DataModel;

public record class Category(
[JsonProperty(PropertyName = "strCategory")] string Name);

