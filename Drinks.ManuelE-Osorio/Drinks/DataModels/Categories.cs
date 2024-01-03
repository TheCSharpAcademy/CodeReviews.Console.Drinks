using System.Text.Json.Serialization;

namespace DrinksProgram;
public class CategoriesJSON
{
    [JsonPropertyName("drinks")] public List<Categories> Categories {get; set;} = [];
}

public class Categories
{
    public string Selected {get; set;} = "";
    [JsonPropertyName("strCategory")] public string Category {get; set;} = "";
}