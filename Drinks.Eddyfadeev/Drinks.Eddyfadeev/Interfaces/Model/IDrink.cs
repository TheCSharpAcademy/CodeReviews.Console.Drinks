namespace Drinks.Eddyfadeev.Interfaces.Model;

/// <summary>
/// Represents an interface for a drink.
/// </summary>
internal interface IDrink
{
    internal string? DrinkId { get; set; }
    internal string? DrinkName { get; set; }
    internal string? DrinkTags { get; set; }
    internal string? DrinkCategory { get; set; }
    internal string? IsAlcoholic { get; set; }
    internal string? DrinkGlassType { get; set; }
    internal string? DrinkInstructions { get; set; }
    internal string? DrinkImage { get; set; }
    internal string[]? Ingredients { get; set; }
    internal string[]? Measures { get; set; }
}