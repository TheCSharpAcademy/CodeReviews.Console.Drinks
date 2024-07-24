using Newtonsoft.Json;

namespace DrinksInfo.Contracts.V1;

/// <summary>
/// A JSON reponse for a collection of categories.
/// </summary>
public class Categories
{
    #region Properties

    [JsonProperty("drinks")]
    public Category[]? Values { get; set; }

    #endregion
}
