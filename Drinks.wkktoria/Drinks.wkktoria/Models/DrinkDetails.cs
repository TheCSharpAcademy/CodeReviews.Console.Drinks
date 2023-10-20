using Newtonsoft.Json;

namespace Drinks.wkktoria.Models;

internal class DrinkDetails
{
    public string? StrDrink { get; set; }
    public object? StrDrinkAlternate { get; set; }
    public object? StrTags { get; set; }
    public object? StrVideo { get; set; }
    public string? StrCategory { get; set; }
    public object? StrIba { get; set; }
    public string? StrAlcoholic { get; set; }
    public string? StrGlass { get; set; }
    public string? StrInstructions { get; set; }
    public object? StrInstructionsEs { get; set; }
    public string? StrInstructionsDe { get; set; }
    public object? StrInstructionsFr { get; set; }
    public string? StrInstructionsIt { get; set; }
    public object? StrInstructionsZhhans { get; set; }
    public object? StrInstructionsZhhant { get; set; }
    public string? StrDrinkThumb { get; set; }
    public string? StrIngredient1 { get; set; }
    public string? StrIngredient2 { get; set; }
    public string? StrIngredient3 { get; set; }
    public string? StrIngredient4 { get; set; }
    public object? StrIngredient5 { get; set; }
    public object? StrIngredient6 { get; set; }
    public object? StrIngredient7 { get; set; }
    public object? StrIngredient8 { get; set; }
    public object? StrIngredient9 { get; set; }
    public object? StrIngredient10 { get; set; }
    public object? StrIngredient11 { get; set; }
    public object? StrIngredient12 { get; set; }
    public object? StrIngredient13 { get; set; }
    public object? StrIngredient14 { get; set; }
    public object? StrIngredient15 { get; set; }
    public string? StrMeasure1 { get; set; }
    public string? StrMeasure2 { get; set; }
    public string? StrMeasure3 { get; set; }
    public string? StrMeasure4 { get; set; }
    public object? StrMeasure5 { get; set; }
    public object? StrMeasure6 { get; set; }
    public object? StrMeasure7 { get; set; }
    public object? StrMeasure8 { get; set; }
    public object? StrMeasure9 { get; set; }
    public object? StrMeasure10 { get; set; }
    public object? StrMeasure11 { get; set; }
    public object? StrMeasure12 { get; set; }
    public object? StrMeasure13 { get; set; }
    public object? StrMeasure14 { get; set; }
    public object? StrMeasure15 { get; set; }
    public object? StrImageSource { get; set; }
    public object? StrImageAttribution { get; set; }
    public string? StrCreativeCommonsConfirmed { get; set; }
    public string? DateModified { get; set; }
}

internal class DrinkDetailsObject
{
    [JsonProperty("drinks")] public List<DrinkDetails>? DrinkDetailsList { get; set; }
}