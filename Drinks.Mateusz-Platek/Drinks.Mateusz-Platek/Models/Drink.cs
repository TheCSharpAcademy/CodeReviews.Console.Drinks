using Newtonsoft.Json;

namespace Drinks.Mateusz_Platek.Models;

public class Drink
{
    [JsonProperty("idDrink")]
    public int id { get; set; }
    [JsonProperty("strDrink")]
    public string name { get; set; }

    public Drink(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}