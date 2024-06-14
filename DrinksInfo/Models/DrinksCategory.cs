using Newtonsoft.Json;
namespace DrinksInfo.Models;

public record DrinksCategory([property: JsonProperty("strCategory")] string Category)
{
    public override string ToString()
    {
        return Category;
    }
}

public record DrinkCategories([property: JsonProperty("drinks")] List<DrinksCategory> Categories);
