using System.Text.Json.Serialization;

namespace Drinks.Models;

public class DrinkInfo
{
    [JsonPropertyName("idDrink")]
    public required string Id { get; set; }

    [JsonPropertyName("strDrink")]
    public required string Name { get; set; }

    [JsonPropertyName("strDrinkAlternate")]
    public required string AlternateName { get; set; }

    [JsonPropertyName("strTags")]
    public required string Tags { get; set; }

    [JsonPropertyName("strVideo")]
    public required string Video { get; set; }

    [JsonPropertyName("strCategory")]
    public required string Category { get; set; }

    [JsonPropertyName("strIBA")]
    public required string Iba { get; set; }

    [JsonPropertyName("strAlcoholic")]
    public required string Alcoholic { get; set; }

    [JsonPropertyName("strGlass")]
    public required string Glass { get; set; }

    [JsonPropertyName("strInstructions")]
    public required string Instructions { get; set; }

    [JsonPropertyName("strInstructionsES")]
    public required string InstructionsES { get; set; }

    [JsonPropertyName("strInstructionsDE")]
    public required string InstructionsDE { get; set; }

    [JsonPropertyName("strInstructionsFR")]
    public required string InstructionsFR { get; set; }

    [JsonPropertyName("strInstructionsIT")]
    public required string InstructionsIT { get; set; }

    [JsonPropertyName("strInstructionsZH-HANS")]
    public required string InstructionsZH_HANS { get; set; }

    [JsonPropertyName("strInstructionsZH-HANT")]
    public required string InstructionsZH_HANT { get; set; }

    [JsonPropertyName("strDrinkThumb")]
    public required string Thumbnail { get; set; }

    [JsonPropertyName("strIngredient1")]
    public required string Ingredient1 { get; set; }

    [JsonPropertyName("strIngredient2")]
    public required string Ingredient2 { get; set; }

    [JsonPropertyName("strIngredient3")]
    public required string Ingredient3 { get; set; }

    [JsonPropertyName("strIngredient4")]
    public required string Ingredient4 { get; set; }

    [JsonPropertyName("strIngredient5")]
    public required string Ingredient5 { get; set; }

    [JsonPropertyName("strIngredient6")]
    public required string Ingredient6 { get; set; }

    [JsonPropertyName("strIngredient7")]
    public required string Ingredient7 { get; set; }

    [JsonPropertyName("strIngredient8")]
    public required string Ingredient8 { get; set; }

    [JsonPropertyName("strIngredient9")]
    public required string Ingredient9 { get; set; }

    [JsonPropertyName("strIngredient10")]
    public required string Ingredient10 { get; set; }

    [JsonPropertyName("strIngredient11")]
    public required string Ingredient11 { get; set; }

    [JsonPropertyName("strIngredient12")]
    public required string Ingredient12 { get; set; }

    [JsonPropertyName("strIngredient13")]
    public required string Ingredient13 { get; set; }

    [JsonPropertyName("strIngredient14")]
    public required string Ingredient14 { get; set; }

    [JsonPropertyName("strIngredient15")]
    public required string Ingredient15 { get; set; }

    [JsonPropertyName("strMeasure1")]
    public required string Measure1 { get; set; }

    [JsonPropertyName("strMeasure2")]
    public required string Measure2 { get; set; }

    [JsonPropertyName("strMeasure3")]
    public required string Measure3 { get; set; }

    [JsonPropertyName("strMeasure4")]
    public required string Measure4 { get; set; }

    [JsonPropertyName("strMeasure5")]
    public required string Measure5 { get; set; }

    [JsonPropertyName("strMeasure6")]
    public required string Measure6 { get; set; }

    [JsonPropertyName("strMeasure7")]
    public required string Measure7 { get; set; }

    [JsonPropertyName("strMeasure8")]
    public required string Measure8 { get; set; }

    [JsonPropertyName("strMeasure9")]
    public required string Measure9 { get; set; }

    [JsonPropertyName("strMeasure10")]
    public required string Measure10 { get; set; }

    [JsonPropertyName("strMeasure11")]
    public required string Measure11 { get; set; }

    [JsonPropertyName("strMeasure12")]
    public required string Measure12 { get; set; }

    [JsonPropertyName("strMeasure13")]
    public required string Measure13 { get; set; }

    [JsonPropertyName("strMeasure14")]
    public required string Measure14 { get; set; }

    [JsonPropertyName("strMeasure15")]
    public required string Measure15 { get; set; }

    [JsonPropertyName("strImageSource")]
    public required string ImageSource { get; set; }

    [JsonPropertyName("strImageAttribution")]
    public required string ImageAttribution { get; set; }

    [JsonPropertyName("strCreativeCommonsConfirmed")]
    public required string CreativeCommonsConfirmed { get; set; }

    [JsonPropertyName("dateModified")]
    public required string DateModified { get; set; }
}

public class DrinkInfoResponse
{
    [JsonPropertyName("drinks")]
    public List<DrinkInfo> Drinks { get; set; } = [];
}