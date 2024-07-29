namespace Drinks.kwm0304.Utils;

public class CleanEndpoint
{
  private const string BaseUrl = "https://www.thecocktaildb.com/api/json/v1/1/";
  public static string GetEndpoint(string api, string? input = null)
  {
    return api switch
    {
      "categories" => $"{BaseUrl}list.php?c=list",
      "drinksInCategory" => $"{BaseUrl}filter.php?c={input}",
      "drinkById" => $"{BaseUrl}lookup.php?i={input}",
      _ => throw new ArgumentException("Invalid endpoint type", nameof(api))
    };
  }
}