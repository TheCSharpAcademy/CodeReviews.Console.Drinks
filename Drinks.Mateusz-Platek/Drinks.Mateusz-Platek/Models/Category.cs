using Newtonsoft.Json;

namespace Drinks.Mateusz_Platek.Models;

public class Category
{
    [JsonProperty("strCategory")]
    public string name { get; set; }

    public Category(string name)
    {
        this.name = name;
    }
}