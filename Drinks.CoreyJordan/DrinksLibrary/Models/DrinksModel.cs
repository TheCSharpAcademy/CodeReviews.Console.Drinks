using Newtonsoft.Json;

namespace DrinksLibrary.Models;
public class DrinksModel
{
    [JsonProperty("drinks")]
    public List<DrinkModel>? DrinkList { get; internal set; }
}
