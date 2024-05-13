using System.Text.Json.Serialization;

namespace Drinks.ASV.Model;

internal class SelectedDrinkCategoryDrinks
{
    public struct DrinksInfo
    {
        [JsonPropertyName("idDrink")]
        public string DrinkId { get; set; }
        [JsonPropertyName("strDrink")]
        public string DrinkName { get; set; }
    }
    [JsonPropertyName("drinks")]
    public List<DrinksInfo> ?Drinks { get; set; }
}