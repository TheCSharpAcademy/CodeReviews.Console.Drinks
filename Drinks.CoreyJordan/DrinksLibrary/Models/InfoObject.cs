using Newtonsoft.Json;

namespace DrinksLibrary.Models;
public class InfoObject
{
    [JsonProperty("drinks")]
    public List<RawInfoModel>? DrinkInfoList { get; set; }
}
