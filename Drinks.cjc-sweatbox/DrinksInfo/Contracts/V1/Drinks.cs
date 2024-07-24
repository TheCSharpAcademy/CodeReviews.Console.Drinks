using Newtonsoft.Json;

namespace DrinksInfo.Contracts.V1;

/// <summary>
/// A JSON reponse for a collection of drinks.
/// </summary>
public class Drinks
{
    #region Properties

    [JsonProperty("drinks")]
    public List<Drink>? Values { get; set; }

    #endregion
}
