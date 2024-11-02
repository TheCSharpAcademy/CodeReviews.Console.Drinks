using Newtonsoft.Json;

namespace DrinksInfo.Class_Objects;

public class Category
{
    [JsonProperty("strCategory")]
    public string StrCategory { get; set; } = null!;
    public int ID { get; set; }
}