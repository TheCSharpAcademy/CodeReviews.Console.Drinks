using Newtonsoft.Json;

namespace Drinks_Info.Models;

internal class Category
{
    [JsonProperty("strCategory")]
    public string? Name { get; init; }
}

class CategoryResponse
{
    [JsonProperty("drinks")]
    public List<Category>? Categories { get; init; }
}