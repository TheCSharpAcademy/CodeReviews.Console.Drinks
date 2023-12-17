using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Drinks.UgniusFalze;

public record DrinkDetails(
    [property: JsonPropertyName("idDrink")]
    int DrinkId,
    [property: JsonPropertyName("strDrink")]
    string DrinksName,
    [property: JsonPropertyName("strDrinkAlternate")]
    string? DrinksAlternateName,
    [property: JsonPropertyName("strTags")]
    string DrinkTags,
    [property: JsonPropertyName("strVideo")]
    Uri? DrinksVideo,
    [property: JsonPropertyName("strCategory")]
    string DrinksCategory,
    [property: JsonPropertyName("strIBA")] string IBACategory,
    [property: JsonPropertyName("strAlcoholic")]
    string Alcoholic,
    [property: JsonPropertyName("strGlass")]
    string DrinksGlass,
    [property: JsonPropertyName("strInstructions")]
    string DrinksInstructions,
    [property: JsonPropertyName("strInstructionsES")]
    string? DrinksInstructionsInSpanish,
    [property: JsonPropertyName("strInstructionsDE")]
    string? DrinksInstructionsInGerman,
    [property: JsonPropertyName("strInstructionsFR")]
    string? DrinksInstructionsInFrench,
    [property: JsonPropertyName("strInstructionsIT")]
    string? DrinksInstructionsInItalian,
    [property: JsonPropertyName("strInstructionsZH-HANS")]
    string? DrinksInstructionsInChineeseSimplified,
    [property: JsonPropertyName("strInstructionsZH-HANT")]
    string? DrinksInstructionsInChineeseTraditional,
    [property: JsonPropertyName("strDrinkThumb")]
    Uri DrinksThumbnailUrl,
    [property: JsonPropertyName("strIngredient1")]
    string? DrinksIngredient1,
    [property: JsonPropertyName("strIngredient2")]
    string? DrinksIngredient2,
    [property: JsonPropertyName("strIngredient3")]
    string? DrinksIngredient3,
    [property: JsonPropertyName("strIngredient4")]
    string? DrinksIngredient4,
    [property: JsonPropertyName("strIngredient5")]
    string? DrinksIngredient5,
    [property: JsonPropertyName("strIngredient6")]
    string? DrinksIngredient6,
    [property: JsonPropertyName("strIngredient7")]
    string? DrinksIngredient7,
    [property: JsonPropertyName("strIngredient8")]
    string? DrinksIngredient8,
    [property: JsonPropertyName("strIngredient9")]
    string? DrinksIngredient9,
    [property: JsonPropertyName("strIngredient10")]
    string? DrinksIngredient10,
    [property: JsonPropertyName("strIngredient11")]
    string? DrinksIngredient11,
    [property: JsonPropertyName("strIngredient12")]
    string? DrinksIngredient12,
    [property: JsonPropertyName("strIngredient13")]
    string? DrinksIngredient13,
    [property: JsonPropertyName("strIngredient14")]
    string? DrinksIngredient14,
    [property: JsonPropertyName("strIngredient15")]
    string? DrinksIngredient15,
    [property: JsonPropertyName("strMeasure1")]
    string? DrinksIngredientMeasure1,
    [property: JsonPropertyName("strMeasure2")]
    string? DrinksIngredientMeasure2,
    [property: JsonPropertyName("strMeasure3")]
    string? DrinksIngredientMeasure3,
    [property: JsonPropertyName("strMeasure4")]
    string? DrinksIngredientMeasure4,
    [property: JsonPropertyName("strMeasure5")]
    string? DrinksIngredientMeasure5,
    [property: JsonPropertyName("strMeasure6")]
    string? DrinksIngredientMeasure6,
    [property: JsonPropertyName("strMeasure7")]
    string? DrinksIngredientMeasure7,
    [property: JsonPropertyName("strMeasure8")]
    string? DrinksIngredientMeasure8,
    [property: JsonPropertyName("strMeasure9")]
    string? DrinksIngredientMeasure9,
    [property: JsonPropertyName("strMeasure10")]
    string? DrinksIngredientMeasure10,
    [property: JsonPropertyName("strMeasure11")]
    string? DrinksIngredientMeasure11,
    [property: JsonPropertyName("strMeasure12")]
    string? DrinksIngredientMeasure12,
    [property: JsonPropertyName("strMeasure13")]
    string? DrinksIngredientMeasure13,
    [property: JsonPropertyName("strMeasure14")]
    string? DrinksIngredientMeasure14,
    [property: JsonPropertyName("strMeasure15")]
    string? DrinksIngredientMeasure15,
    [property: JsonPropertyName("strImageSource")]
    Uri? DrinksImageSource,
    [property: JsonPropertyName("strImageAttribution")]
    string? DrinksImageAttribution,
    [property: JsonPropertyName("strCreativeCommonsConfirmed")]
    string? DrinksCreativeCommonsConfirmed,
    [property: JsonPropertyName("dateModified")]
    string? DrinksInfoDateModified
)
{

    public List<List<object>> ConvertToList()
    {
        var result = new List<List<object>>();
        var properties = GetType().GetProperties();
        foreach (var propertyInfo in properties)
        {
            var property = new List<object>();
            object? value;
            if ((value = propertyInfo.GetValue(this)) != null)
            {
                string name =Regex.Replace(propertyInfo.Name, "(\\B[A-Z])",
                    " $1");
                if (propertyInfo.PropertyType == typeof(string))
                {
                    property.Add(name);
                    string? cleaned = (value as string)?.Trim();
                    property.Add(cleaned);
                }
                else
                {
                    property.Add(name);
                    property.Add(value);
                }
                result.Add(property);
            }
        }

        return result;
    }
}