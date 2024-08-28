using Drinks.Eddyfadeev.Interfaces.Model;
using Drinks.Eddyfadeev.Mappers;
using Newtonsoft.Json;

namespace Drinks.Eddyfadeev.Models;

[JsonConverter(typeof(DrinkMapper))]
internal class Drink : IDrink
{
    public string? DrinkId { get; set; }
    public string? DrinkName { get; set; }
    public string? DrinkTags { get; set; }
    public string? DrinkCategory { get; set; }
    public string? IsAlcoholic { get; set; }
    public string? DrinkGlassType { get; set; }
    public string? DrinkInstructions { get; set; }
    public string? DrinkImage { get; set; }
    public string[]? Ingredients { get; set; }
    public string[]? Measures { get; set; }
}