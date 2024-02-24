using Newtonsoft.Json;

namespace DrinksConsoleApp;

public record class Category(
[JsonProperty(PropertyName = "strCategory")] string Name);

