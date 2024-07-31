using Spectre.Console;
using System.Text.Json.Serialization;

namespace DrinksInfo;
public class DrinksResponse {
    public Drink[]? Drinks { get; set; }
}

public class Drink {
    [JsonPropertyName("idDrink")]
    public string? idDrink { get; set; }

    [JsonPropertyName("strDrink")]
    public string? strDrink { get; set; }

    [JsonPropertyName("strDrinkAlternate")]
    public string? strDrinkAlternate { get; set; }

    [JsonPropertyName("strTags")]
    public string? strTags { get; set; }

    [JsonPropertyName("strVideo")]
    public string? strVideo { get; set; }

    [JsonPropertyName("strCategory")]
    public string? strCategory { get; set; }

    [JsonPropertyName("strIBA")]
    public string? strIBA { get; set; }

    [JsonPropertyName("strAlcoholic")]
    public string? strAlcoholic { get; set; }

    [JsonPropertyName("strGlass")]
    public string? strGlass { get; set; }

    [JsonPropertyName("strInstructions")]
    public string? strInstructions { get; set; }

    [JsonPropertyName("strInstructionsES")]
    public string? strInstructionsES { get; set; }

    [JsonPropertyName("strInstructionsDE")]
    public string? strInstructionsDE { get; set; }

    [JsonPropertyName("strInstructionsFR")]
    public string? strInstructionsFR { get; set; }

    [JsonPropertyName("strInstructionsIT")]
    public string? strInstructionsIT { get; set; }

    [JsonPropertyName("strInstructionsZH-HANS")]
    public string? strInstructionsZHHANS { get; set; }

    [JsonPropertyName("strInstructionsZH-HANT")]
    public string? strInstructionsZHHANT { get; set; }

    [JsonPropertyName("strDrinkThumb")]
    public string? strDrinkThumb { get; set; }

    [JsonPropertyName("strIngredient1")]
    public string? strIngredient1 { get; set; }

    [JsonPropertyName("strIngredient2")]
    public string? strIngredient2 { get; set; }

    [JsonPropertyName("strIngredient3")]
    public string? strIngredient3 { get; set; }

    [JsonPropertyName("strIngredient4")]
    public string? strIngredient4 { get; set; }

    [JsonPropertyName("strIngredient5")]
    public string? strIngredient5 { get; set; }

    [JsonPropertyName("strIngredient6")]
    public string? strIngredient6 { get; set; }

    [JsonPropertyName("strIngredient7")]
    public string? strIngredient7 { get; set; }

    [JsonPropertyName("strIngredient8")]
    public string? strIngredient8 { get; set; }

    [JsonPropertyName("strIngredient9")]
    public string? strIngredient9 { get; set; }

    [JsonPropertyName("strIngredient10")]
    public string? strIngredient10 { get; set; }

    [JsonPropertyName("strIngredient11")]
    public string? strIngredient11 { get; set; }

    [JsonPropertyName("strIngredient12")]
    public string? strIngredient12 { get; set; }

    [JsonPropertyName("strIngredient13")]
    public string? strIngredient13 { get; set; }

    [JsonPropertyName("strIngredient14")]
    public string? strIngredient14 { get; set; }

    [JsonPropertyName("strIngredient15")]
    public string? strIngredient15 { get; set; }

    [JsonPropertyName("strMeasure1")]
    public string? strMeasure1 { get; set; }

    [JsonPropertyName("strMeasure2")]
    public string? strMeasure2 { get; set; }

    [JsonPropertyName("strMeasure3")]
    public string? strMeasure3 { get; set; }

    [JsonPropertyName("strMeasure4")]
    public string? strMeasure4 { get; set; }

    [JsonPropertyName("strMeasure5")]
    public string? strMeasure5 { get; set; }

    [JsonPropertyName("strMeasure6")]
    public string? strMeasure6 { get; set; }

    [JsonPropertyName("strMeasure7")]
    public string? strMeasure7 { get; set; }

    [JsonPropertyName("strMeasure8")]
    public string? strMeasure8 { get; set; }

    [JsonPropertyName("strMeasure9")]
    public string? strMeasure9 { get; set; }

    [JsonPropertyName("strMeasure10")]
    public string? strMeasure10 { get; set; }

    [JsonPropertyName("strMeasure11")]
    public string? strMeasure11 { get; set; }

    [JsonPropertyName("strMeasure12")]
    public string? strMeasure12 { get; set; }

    [JsonPropertyName("strMeasure13")]
    public string? strMeasure13 { get; set; }

    [JsonPropertyName("strMeasure14")]
    public string? strMeasure14 { get; set; }

    [JsonPropertyName("strMeasure15")]
    public string? strMeasure15 { get; set; }

    [JsonPropertyName("strImageSource")]
    public string? strImageSource { get; set; }

    [JsonPropertyName("strImageAttribution")]
    public string? strImageAttribution { get; set; }

    [JsonPropertyName("strCreativeCommonsConfirmed")]
    public string? strCreativeCommonsConfirmed { get; set; }

    [JsonPropertyName("dateModified")]
    public string? dateModified { get; set; }

    public void PrintInfo() {
        AnsiConsole.MarkupLine(strDrink);
    }
}

