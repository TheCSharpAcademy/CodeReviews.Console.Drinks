using System.Text.Json;
using Drinks.kwm0304.Models;

namespace Drinks.kwm0304;
public class DrinkDetailProcessor
{
  public static void ProcessDrinkDetail(DrinkDetail drink)
  {
    if (drink.AdditionalProperties == null) return;
    var propertiesToRemove = new List<string>();
    foreach (var prop in drink.AdditionalProperties)
    {
      if (prop.Key.StartsWith("strIngredient") && prop.Value.ValueKind != JsonValueKind.Null)
      {
        string? ingredient = prop.Value.GetString();
        if (!string.IsNullOrEmpty(ingredient))
        {
          drink.Ingredients.Add(ingredient);
        }
        propertiesToRemove.Add(prop.Key);
      }
      else if (prop.Key.StartsWith("strMeasure") && prop.Value.ValueKind != JsonValueKind.Null)
      {
        string? measure = prop.Value.GetString();
        if (!string.IsNullOrEmpty(measure))
        {
          drink.Measures.Add(measure);
        }
        propertiesToRemove.Add(prop.Key);
      }
    }
    foreach (var key in propertiesToRemove)
    {
      drink.AdditionalProperties.Remove(key);
    }
  }
}