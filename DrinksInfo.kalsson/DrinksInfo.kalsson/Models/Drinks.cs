using Newtonsoft.Json;

namespace DrinksInfo.kalsson.Models;

/// <summary>
/// Represents a collection of drinks.
/// </summary>
public class Drinks
{
    /// <summary>
    /// Represents a list of drinks.
    /// </summary>
    [JsonProperty("drinks")]
    public List<Drink> DrinksList { get; set; }
}

/// <summary>
/// Represents a drink.
/// </summary>
public class Drink
{
    /// <summary>
    /// Represents the unique identifier of a drink.
    /// </summary>
    public string idDrink { get; set; }

    /// <summary>
    /// Gets or sets the name of the drink.
    /// </summary>
    public string strDrink { get; set; }
}