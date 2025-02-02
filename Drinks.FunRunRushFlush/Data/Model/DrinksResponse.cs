using System.Text.Json.Serialization;

namespace Drinks.FunRunRushFlush.Data.Model;

//https://json2csharp.com/
// DrinksResponse myDeserializedClass = JsonConvert.DeserializeObject<DrinksResponse>(myJsonResponse);

public record DrinksResponse(
    [property: JsonPropertyName("drinks")] List<Drink> Drinks
);

public record Drink(
    [property: JsonPropertyName("idDrink")] string IdDrink,
    [property: JsonPropertyName("strDrink")] string StrDrink,
    [property: JsonPropertyName("strDrinkAlternate")] string? StrDrinkAlternate, 
    [property: JsonPropertyName("strTags")] string? StrTags,
    [property: JsonPropertyName("strVideo")] string? StrVideo,
    [property: JsonPropertyName("strCategory")] string? StrCategory,
    [property: JsonPropertyName("strIBA")] string? StrIBA,
    [property: JsonPropertyName("strAlcoholic")] string? StrAlcoholic,
    [property: JsonPropertyName("strGlass")] string? StrGlass,
    [property: JsonPropertyName("strInstructions")] string? StrInstructions,
    [property: JsonPropertyName("strInstructionsES")] string? StrInstructionsES,
    [property: JsonPropertyName("strInstructionsDE")] string? StrInstructionsDE,
    [property: JsonPropertyName("strInstructionsFR")] string? StrInstructionsFR,
    [property: JsonPropertyName("strInstructionsIT")] string? StrInstructionsIT,
    [property: JsonPropertyName("strInstructionsZH-HANS")] string? StrInstructionsZHHANS,
    [property: JsonPropertyName("strInstructionsZH-HANT")] string? StrInstructionsZHHANT,
    [property: JsonPropertyName("strDrinkThumb")] string? StrDrinkThumb,
    [property: JsonPropertyName("strIngredient1")] string? StrIngredient1,
    [property: JsonPropertyName("strIngredient2")] string? StrIngredient2,
    [property: JsonPropertyName("strIngredient3")] string? StrIngredient3,
    [property: JsonPropertyName("strIngredient4")] string? StrIngredient4,
    [property: JsonPropertyName("strIngredient5")] string? StrIngredient5,
    [property: JsonPropertyName("strIngredient6")] string? StrIngredient6,
    [property: JsonPropertyName("strIngredient7")] string? StrIngredient7,
    [property: JsonPropertyName("strIngredient8")] string? StrIngredient8,
    [property: JsonPropertyName("strIngredient9")] string? StrIngredient9,
    [property: JsonPropertyName("strIngredient10")] string? StrIngredient10,
    [property: JsonPropertyName("strIngredient11")] string? StrIngredient11,
    [property: JsonPropertyName("strIngredient12")] string? StrIngredient12,
    [property: JsonPropertyName("strIngredient13")] string? StrIngredient13,
    [property: JsonPropertyName("strIngredient14")] string? StrIngredient14,
    [property: JsonPropertyName("strIngredient15")] string? StrIngredient15,
    [property: JsonPropertyName("strMeasure1")] string? StrMeasure1,
    [property: JsonPropertyName("strMeasure2")] string? StrMeasure2,
    [property: JsonPropertyName("strMeasure3")] string? StrMeasure3,
    [property: JsonPropertyName("strMeasure4")] string? StrMeasure4,
    [property: JsonPropertyName("strMeasure5")] string? StrMeasure5,
    [property: JsonPropertyName("strMeasure6")] string? StrMeasure6,
    [property: JsonPropertyName("strMeasure7")] string? StrMeasure7,
    [property: JsonPropertyName("strMeasure8")] string? StrMeasure8,
    [property: JsonPropertyName("strMeasure9")] string? StrMeasure9,
    [property: JsonPropertyName("strMeasure10")] string? StrMeasure10,
    [property: JsonPropertyName("strMeasure11")] string? StrMeasure11,
    [property: JsonPropertyName("strMeasure12")] string? StrMeasure12,
    [property: JsonPropertyName("strMeasure13")] string? StrMeasure13,
    [property: JsonPropertyName("strMeasure14")] string? StrMeasure14,
    [property: JsonPropertyName("strMeasure15")] string? StrMeasure15,
    [property: JsonPropertyName("strImageSource")] string? StrImageSource,
    [property: JsonPropertyName("strImageAttribution")] string? StrImageAttribution,
    [property: JsonPropertyName("strCreativeCommonsConfirmed")] string? StrCreativeCommonsConfirmed,
    [property: JsonPropertyName("dateModified")] string? DateModified
);




