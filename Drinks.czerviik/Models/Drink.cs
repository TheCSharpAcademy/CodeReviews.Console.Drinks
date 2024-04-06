using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace drinks_info;

public class Drink : IModelEntity
{
    [JsonProperty("strDrink")] public string Name { get; set; }
    [JsonProperty("idDrink")] public string Id { get; set; }
}

public class Drinks
{
    [JsonProperty("drinks")]
    public List<Drink> DrinksList { get; set; }
}

