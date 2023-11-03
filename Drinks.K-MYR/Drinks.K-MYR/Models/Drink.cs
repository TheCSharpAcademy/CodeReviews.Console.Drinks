using System.Text.Json.Serialization;

namespace Drinks.K_MYR.Models;

internal record class DrinkResponse
(
    [property: JsonPropertyName("drinks")]
    IEnumerable<Drink> Drinks
);

internal record class Drink
(    
    [property: JsonPropertyName("idDrink")] 
    int Id,
    [property: JsonPropertyName("strDrink")] 
    string Name
);
