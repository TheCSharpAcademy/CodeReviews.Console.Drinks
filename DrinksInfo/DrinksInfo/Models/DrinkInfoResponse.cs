using System.Text.Json.Serialization;

namespace DrinksInfo;

public class DrinkInfoResponse
{
    [property: JsonPropertyName("drinks")]
    public List<DrinkProperties>? Info { get; set; }
}

public class DrinkProperties
{
    [property: JsonPropertyName("idDrink")]
    public string? Id { get; set; }
    [property: JsonPropertyName("strDrink")]
    public string? Name { get; set; }
    [property: JsonPropertyName("strDrinkAlternate")]
    public string? Alternative { get; set; }
    [property: JsonPropertyName("strTags")]
    public string? Tags { get; set; }
    [property: JsonPropertyName("strVideo")]
    public string? Video { get; set; }
    [property: JsonPropertyName("strCategory")]
    public string? Category { get; set; }
    [property: JsonPropertyName("strIBA")]
    public string? IBA { get; set; }
    [property: JsonPropertyName("strAlcoholic")]
    public string? Alcocholic { get; set; }
    [property: JsonPropertyName("strGlass")]
    public string? Glass { get; set; }
    [property: JsonPropertyName("strInstructions")]
    public string? Instructions { get; set; }
    [property: JsonPropertyName("strInstructionsES")]
    public string? InstructionsES { get; set; }
    [property: JsonPropertyName("strInstructionsDE")]
    public string? InstructionsDE { get; set; }
    [property: JsonPropertyName("strInstructionsFR")]
    public string? InstructionsFR { get; set; }
    [property: JsonPropertyName("strInstructionsIT")]
    public string? InstructionsIT { get; set; }
    [property: JsonPropertyName("strInstructionsZHHANS")]
    public string? InstructionsZHHANS { get; set; }
    [property: JsonPropertyName("strInstructionsZHHANT")]
    public string? InstructionsZHHANT { get; set; }
    [property: JsonPropertyName("strDrinkThumb")]
    public string? ImageURL { get; set; }
    [property: JsonPropertyName("strIngredient1")]
    public string? Ingredient1 { get; set; }
    [property: JsonPropertyName("strIngredient2")]
    public string? Ingredient2 { get; set; }
    [property: JsonPropertyName("strIngredient3")]
    public string? Ingredient3 { get; set; }
    [property: JsonPropertyName("strIngredient4")]
    public string? Ingredient4 { get; set; }
    [property: JsonPropertyName("strIngredient5")]
    public string? Ingredient5 { get; set; }
    [property: JsonPropertyName("strIngredient6")]
    public string? Ingredient6 { get; set; }
    [property: JsonPropertyName("strIngredient7")]
    public string? Ingredient7 { get; set; }
    [property: JsonPropertyName("strIngredient8")]
    public string? Ingredient8 { get; set; }
    [property: JsonPropertyName("strIngredient9")]
    public string? Ingredient9 { get; set; }
    [property: JsonPropertyName("strIngredient10")]
    public string? Ingredient10 { get; set; }
    [property: JsonPropertyName("strIngredient11")]
    public string? Ingredient11 { get; set; }
    [property: JsonPropertyName("strIngredient12")]
    public string? Ingredient12 { get; set; }
    [property: JsonPropertyName("strIngredient13")]
    public string? Ingredient13 { get; set; }
    [property: JsonPropertyName("strIngredient14")]
    public string? Ingredient14 { get; set; }
    [property: JsonPropertyName("strIngredient15")]
    public string? Ingredient15 { get; set; }
    [property: JsonPropertyName("strMeasure1")]
    public string? Measure1 { get; set; }
    [property: JsonPropertyName("strMeasure2")]
    public string? Measure2 { get; set; }
    [property: JsonPropertyName("strMeasure3")]
    public string? Measure3 { get; set; }
    [property: JsonPropertyName("strMeasure4")]
    public string? Measure4 { get; set; }
    [property: JsonPropertyName("strMeasure5")]
    public string? Measure5 { get; set; }
    [property: JsonPropertyName("strMeasure6")]
    public string? Measure6 { get; set; }
    [property: JsonPropertyName("strMeasure7")]
    public string? Measure7 { get; set; }
    [property: JsonPropertyName("strMeasure8")]
    public string? Measure8 { get; set; }
    [property: JsonPropertyName("strMeasure9")]
    public string? Measure9 { get; set; }
    [property: JsonPropertyName("strMeasure10")]
    public string? Measure10 { get; set; }
    [property: JsonPropertyName("strMeasure11")]
    public string? Measure11 { get; set; }
    [property: JsonPropertyName("strMeasure12")]
    public string? Measure12 { get; set; }
    [property: JsonPropertyName("strMeasure13")]
    public string? Measure13 { get; set; }
    [property: JsonPropertyName("strMeasure14")]
    public string? Measure14 { get; set; }
    [property: JsonPropertyName("strMeasure15")]
    public string? Measure15 { get; set; }
    [property: JsonPropertyName("strImageSource")]
    public string? ImageSource { get; set; }
    [property: JsonPropertyName("strImageAttribution")]
    public string? ImageAttribution { get; set; }
    [property: JsonPropertyName("strCreativeCommonsConfirmed")]
    public string? CreativeCommonsConfirmed { get; set; }
    [property: JsonPropertyName("dateModified")]
    public string? DateModified { get; set; }
}