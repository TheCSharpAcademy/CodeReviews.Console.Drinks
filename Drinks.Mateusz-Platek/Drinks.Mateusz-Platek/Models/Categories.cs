using Newtonsoft.Json;

namespace Drinks.Mateusz_Platek.Models;

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category>? list { get; set; }

    public Categories(List<Category>? list)
    {
        this.list = list;
    }
}