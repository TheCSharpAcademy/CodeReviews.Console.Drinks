using Newtonsoft.Json;

namespace Drinks.Mateusz_Platek.Models;

public class Drinks
{
    [JsonProperty("drinks")]
    public List<Drink> list { get; set; }

    public Drinks(List<Drink> list)
    {
        this.list = list;
    }
}