using Newtonsoft.Json;
using System.Collections.Generic;

namespace DrinksInfo.Models
{
  public class DrinkInfo
  {
    [JsonProperty("strDrink")]
    public string Name { get; set; }

    [JsonProperty("idDrink")]
    public string DrinkId { get; set; }

    [JsonProperty("strAlcoholic")]
    public string Type { get; set; }

    [JsonProperty("strInstructions")]
    public string Instructions { get; set; }

    [JsonProperty("strGlass")]
    public string Glass { get; set; }

    [JsonProperty("strCategory")]
    public string Category { get; set; }

    [JsonProperty("strIngredient1")]
    public string Ingredient1 { get; set; }

    [JsonProperty("strIngredient2")]
    public string Ingredient2 { get; set; }

    [JsonProperty("strIngredient3")]
    public string Ingredient3 { get; set; }

    [JsonProperty("strIngredient4")]
    public string Ingredient4 { get; set; }

    [JsonProperty("strIngredient5")]
    public string Ingredient5 { get; set; }

    [JsonProperty("strIngredient6")]
    public string Ingredient6 { get; set; }

    [JsonProperty("strIngredient7")]
    public string Ingredient7 { get; set; }

    [JsonProperty("strIngredient8")]
    public string Ingredient8 { get; set; }

    [JsonProperty("strIngredient9")]
    public string Ingredient9 { get; set; }

    [JsonProperty("strIngredient10")]
    public string Ingredient10 { get; set; }

    [JsonProperty("strIngredient11")]
    public string Ingredient11 { get; set; }

    [JsonProperty("strIngredient12")]
    public string Ingredient12 { get; set; }

    [JsonProperty("strIngredient13")]
    public string Ingredient13 { get; set; }

    [JsonProperty("strIngredient14")]
    public string Ingredient14 { get; set; }

    [JsonProperty("strIngredient15")]
    public string Ingredient15 { get; set; }

    [JsonProperty("strMeasure1")]
    public string Measure1 { get; set; }

    [JsonProperty("strMeasure2")]
    public string Measure2 { get; set; }

    [JsonProperty("strMeasure3")]
    public string Measure3 { get; set; }

    [JsonProperty("strMeasure4")]
    public string Measure4 { get; set; }

    [JsonProperty("strMeasure5")]
    public string Measure5 { get; set; }

    [JsonProperty("strMeasure6")]
    public string Measure6 { get; set; }

    [JsonProperty("strMeasure7")]
    public string Measure7 { get; set; }

    [JsonProperty("strMeasure8")]
    public string Measure8 { get; set; }

    [JsonProperty("strMeasure9")]
    public string Measure9 { get; set; }

    [JsonProperty("strMeasure10")]
    public string Measure10 { get; set; }

    [JsonProperty("strMeasure11")]
    public string Measure11 { get; set; }

    [JsonProperty("strMeasure12")]
    public string Measure12 { get; set; }

    [JsonProperty("strMeasure13")]
    public string Measure13 { get; set; }

    [JsonProperty("strMeasure14")]
    public string Measure14 { get; set; }

    [JsonProperty("strMeasure15")]
    public string Measure15 { get; set; }

    public List<(string Ingredient, string Measure)> GetIngredients()
    {
      var ingredients = new List<(string Ingredient, string Measure)>();
      for (int i = 1; i <= 15; i++)
      {
        var ingredient = GetType().GetProperty($"Ingredient{i}")?.GetValue(this) as string;
        var measure = GetType().GetProperty($"Measure{i}")?.GetValue(this) as string;
        if (!string.IsNullOrEmpty(ingredient))
        {
          ingredients.Add((ingredient.Trim(), measure?.Trim() ?? ""));
        }
      }
      return ingredients;
    }
  }

  public class DrinksInformation
  {
    [JsonProperty("drinks")]
    public List<DrinkInfo> ListDrinksInfo { get; set; } = new List<DrinkInfo>();
  }
}