using System.Text.Json.Serialization;

namespace Buutyful.Drinks.Models;
public class CategoriesResponse
{
    [JsonPropertyName("drinks")]
    public List<Category> Categories { get; set; } = new();
}

public class Category
{
    [JsonPropertyName("strCategory")]
    public string StrCategory { get; set; }
}

public class DrinksInCategoryResponse
{
    [JsonPropertyName("drinks")]
    public List<Drink> Drinks { get; set; } = new();
}

public class Drink
{
    [JsonPropertyName("idDrink")]
    public string IdDrink { get; set; }

    [JsonPropertyName("strDrink")]
    public string StrDrink { get; set; }

    [JsonPropertyName("strDrinkAlternate")]
    public string StrDrinkAlternate { get; set; }

    [JsonPropertyName("strCategory")]
    public string StrCategory { get; set; }

    [JsonPropertyName("strIBA")]
    public string StrIBA { get; set; }

    [JsonPropertyName("strAlcoholic")]
    public string StrAlcoholic { get; set; }

    [JsonPropertyName("strGlass")]
    public string StrGlass { get; set; }

    [JsonPropertyName("strInstructions")]
    public string StrInstructions { get; set; }

    [JsonPropertyName("strIngredient1")]
    public string StrIngredient1 { get; set; }

    [JsonPropertyName("strIngredient2")]
    public string StrIngredient2 { get; set; }

    [JsonPropertyName("strIngredient3")]
    public string StrIngredient3 { get; set; }

    [JsonPropertyName("strIngredient4")]
    public string StrIngredient4 { get; set; }

    [JsonPropertyName("strIngredient5")]
    public string StrIngredient5 { get; set; }

    [JsonPropertyName("strIngredient6")]
    public string StrIngredient6 { get; set; }

}

