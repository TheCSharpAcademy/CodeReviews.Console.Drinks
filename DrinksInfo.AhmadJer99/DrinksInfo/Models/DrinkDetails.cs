using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class DrinkDetails
{
    [JsonProperty("drinks")]
    public Drink[]? Drinks { get; set; }
}

public class Drink
{
    [JsonProperty("strDrink")]
    public string? DrinkName { get; set; }
    [JsonProperty("strCategory")]
    public string? DrinkCategory { get; set; }
    [JsonProperty("strAlcoholic")]
    public string? IsDrinkAlcoholic { get; set; }
    [JsonProperty("strGlass")]
    public string? DrinkGlassType { get; set; }
    [JsonProperty("strInstructions")]
    public string? DrinkMakeInstructions { get; set; }

    public Dictionary<int, string?> Ingredients = new();

    [JsonProperty("strIngredient1")]
    public string? Ingredient1
    {
        get => Ingredients.TryGetValue(1, out var v) ? v : null;
        set => Ingredients[1] = value;
    }

    [JsonProperty("strIngredient2")]
    public string? Ingredient2
    {
        get => Ingredients.TryGetValue(2, out var v) ? v : null;
        set => Ingredients[2] = value;
    }

    [JsonProperty("strIngredient3")]
    public string? Ingredient3
    {
        get => Ingredients.TryGetValue(3, out var v) ? v : null;
        set => Ingredients[3] = value;
    }

    [JsonProperty("strIngredient4")]
    public string? Ingredient4
    {
        get => Ingredients.TryGetValue(4, out var v) ? v : null;
        set => Ingredients[4] = value;
    }

    [JsonProperty("strIngredient5")]
    public string? Ingredient5
    {
        get => Ingredients.TryGetValue(5, out var v) ? v : null;
        set => Ingredients[5] = value;
    }

    [JsonProperty("strIngredient6")]
    public string? Ingredient6
    {
        get => Ingredients.TryGetValue(6, out var v) ? v : null;
        set => Ingredients[6] = value;
    }

    [JsonProperty("strIngredient7")]
    public string? Ingredient7
    {
        get => Ingredients.TryGetValue(7, out var v) ? v : null;
        set => Ingredients[7] = value;
    }

    [JsonProperty("strIngredient8")]
    public string? Ingredient8
    {
        get => Ingredients.TryGetValue(8, out var v) ? v : null;
        set => Ingredients[8] = value;
    }

    [JsonProperty("strIngredient9")]
    public string? Ingredient9
    {
        get => Ingredients.TryGetValue(9, out var v) ? v : null;
        set => Ingredients[9] = value;
    }

    [JsonProperty("strIngredient10")]
    public string? Ingredient10
    {
        get => Ingredients.TryGetValue(10, out var v) ? v : null;
        set => Ingredients[10] = value;
    }

    [JsonProperty("strIngredient11")]
    public string? Ingredient11
    {
        get => Ingredients.TryGetValue(11, out var v) ? v : null;
        set => Ingredients[11] = value;
    }

    [JsonProperty("strIngredient12")]
    public string? Ingredient12
    {
        get => Ingredients.TryGetValue(12, out var v) ? v : null;
        set => Ingredients[12] = value;
    }

    [JsonProperty("strIngredient13")]
    public string? Ingredient13
    {
        get => Ingredients.TryGetValue(13, out var v) ? v : null;
        set => Ingredients[13] = value;
    }

    [JsonProperty("strIngredient14")]
    public string? Ingredient14
    {
        get => Ingredients.TryGetValue(14, out var v) ? v : null;
        set => Ingredients[14] = value;
    }

    [JsonProperty("strIngredient15")]
    public string? Ingredient15
    {
        get => Ingredients.TryGetValue(15, out var v) ? v : null;
        set => Ingredients[15] = value;
    }

    public Dictionary<int, string?> Measures = new();

    [JsonProperty("strMeasure1")]
    public string? Measure1
    {
        get => Measures.TryGetValue(1, out var v) ? v : null;
        set => Measures[1] = value;
    }

    [JsonProperty("strMeasure2")]
    public string? Measure2
    {
        get => Measures.TryGetValue(2, out var v) ? v : null;
        set => Measures[2] = value;
    }

    [JsonProperty("strMeasure3")]
    public string? Measure3
    {
        get => Measures.TryGetValue(3, out var v) ? v : null;
        set => Measures[3] = value;
    }

    [JsonProperty("strMeasure4")]
    public string? Measure4
    {
        get => Measures.TryGetValue(4, out var v) ? v : null;
        set => Measures[4] = value;
    }

    [JsonProperty("strMeasure5")]
    public string? Measure5
    {
        get => Measures.TryGetValue(5, out var v) ? v : null;
        set => Measures[5] = value;
    }

    [JsonProperty("strMeasure6")]
    public string? Measure6
    {
        get => Measures.TryGetValue(6, out var v) ? v : null;
        set => Measures[6] = value;
    }

    [JsonProperty("strMeasure7")]
    public string? Measure7
    {
        get => Measures.TryGetValue(7, out var v) ? v : null;
        set => Measures[7] = value;
    }

    [JsonProperty("strMeasure8")]
    public string? Measure8
    {
        get => Measures.TryGetValue(8, out var v) ? v : null;
        set => Measures[8] = value;
    }

    [JsonProperty("strMeasure9")]
    public string? Measure9
    {
        get => Measures.TryGetValue(9, out var v) ? v : null;
        set => Measures[9] = value;
    }

    [JsonProperty("strMeasure10")]
    public string? Measure10
    {
        get => Measures.TryGetValue(10, out var v) ? v : null;
        set => Measures[10] = value;
    }

    [JsonProperty("strMeasure11")]
    public string? Measure11
    {
        get => Measures.TryGetValue(11, out var v) ? v : null;
        set => Measures[11] = value;
    }

    [JsonProperty("strMeasure12")]
    public string? Measure12
    {
        get => Measures.TryGetValue(12, out var v) ? v : null;
        set => Measures[12] = value;
    }

    [JsonProperty("strMeasure13")]
    public string? Measure13
    {
        get => Measures.TryGetValue(13, out var v) ? v : null;
        set => Measures[13] = value;
    }

    [JsonProperty("strMeasure14")]
    public string? Measure14
    {
        get => Measures.TryGetValue(14, out var v) ? v : null;
        set => Measures[14] = value;
    }

    [JsonProperty("strMeasure15")]
    public string? Measure15
    {
        get => Measures.TryGetValue(15, out var v) ? v : null;
        set => Measures[15] = value;
    }
}