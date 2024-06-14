﻿using Newtonsoft.Json;

public record DrinkDetail(
    [property: JsonProperty("idDrink")][property: JsonConverter(typeof(JsonConverter))] int Id,
    [property: JsonProperty("strDrink", NullValueHandling = NullValueHandling.Ignore)] string Name,
    [property: JsonProperty("strDrinkAlternate", NullValueHandling = NullValueHandling.Ignore)] object AlternateName,
    [property: JsonProperty("strTags", NullValueHandling = NullValueHandling.Ignore)] string Tags,
    [property: JsonProperty("strVideo", NullValueHandling = NullValueHandling.Ignore)] object Video,
    [property: JsonProperty("strCategory", NullValueHandling = NullValueHandling.Ignore)] string Category,
    [property: JsonProperty("strIBA", NullValueHandling = NullValueHandling.Ignore)] string IBA,
    [property: JsonProperty("strAlcoholic", NullValueHandling = NullValueHandling.Ignore)] string Alcoholic,
    [property: JsonProperty("strGlass", NullValueHandling = NullValueHandling.Ignore)] string Glass,
    [property: JsonProperty("strInstructions", NullValueHandling = NullValueHandling.Ignore)] string Instructions,
    [property: JsonProperty("strInstructionsES", NullValueHandling = NullValueHandling.Ignore)] object InstructionsES,
    [property: JsonProperty("strInstructionsDE", NullValueHandling = NullValueHandling.Ignore)] string InstructionsDE,
    [property: JsonProperty("strInstructionsFR", NullValueHandling = NullValueHandling.Ignore)] object InstructionsFR,
    [property: JsonProperty("strInstructionsIT", NullValueHandling = NullValueHandling.Ignore)] string InstructionsIT,
    [property: JsonProperty("strInstructionsZH-HANS", NullValueHandling = NullValueHandling.Ignore)] object InstructionsZHHANS,
    [property: JsonProperty("strInstructionsZH-HANT", NullValueHandling = NullValueHandling.Ignore)] object InstructionsZHHANT,
    [property: JsonProperty("strDrinkThumb", NullValueHandling = NullValueHandling.Ignore)] string DrinkThumb,
    [property: JsonProperty("strIngredient1", NullValueHandling = NullValueHandling.Ignore)] string Ingredient1,
    [property: JsonProperty("strIngredient2", NullValueHandling = NullValueHandling.Ignore)] string Ingredient2,
    [property: JsonProperty("strIngredient3", NullValueHandling = NullValueHandling.Ignore)] string Ingredient3,
    [property: JsonProperty("strIngredient4", NullValueHandling = NullValueHandling.Ignore)] string Ingredient4,
    [property: JsonProperty("strIngredient5", NullValueHandling = NullValueHandling.Ignore)] string Ingredient5,
    [property: JsonProperty("strIngredient6", NullValueHandling = NullValueHandling.Ignore)] string Ingredient6,
    [property: JsonProperty("strIngredient7", NullValueHandling = NullValueHandling.Ignore)] string Ingredient7,
    [property: JsonProperty("strIngredient8", NullValueHandling = NullValueHandling.Ignore)] object Ingredient8,
    [property: JsonProperty("strIngredient9", NullValueHandling = NullValueHandling.Ignore)] object Ingredient9,
    [property: JsonProperty("strIngredient10", NullValueHandling = NullValueHandling.Ignore)] object Ingredient10,
    [property: JsonProperty("strIngredient11", NullValueHandling = NullValueHandling.Ignore)] object Ingredient11,
    [property: JsonProperty("strIngredient12", NullValueHandling = NullValueHandling.Ignore)] object Ingredient12,
    [property: JsonProperty("strIngredient13", NullValueHandling = NullValueHandling.Ignore)] object Ingredient13,
    [property: JsonProperty("strIngredient14", NullValueHandling = NullValueHandling.Ignore)] object Ingredient14,
    [property: JsonProperty("strIngredient15", NullValueHandling = NullValueHandling.Ignore)] object Ingredient15,
    [property: JsonProperty("strMeasure1", NullValueHandling = NullValueHandling.Ignore)] string Measure1,
    [property: JsonProperty("strMeasure2", NullValueHandling = NullValueHandling.Ignore)] string Measure2,
    [property: JsonProperty("strMeasure3", NullValueHandling = NullValueHandling.Ignore)] string Measure3,
    [property: JsonProperty("strMeasure4", NullValueHandling = NullValueHandling.Ignore)] string Measure4,
    [property: JsonProperty("strMeasure5", NullValueHandling = NullValueHandling.Ignore)] string Measure5,
    [property: JsonProperty("strMeasure6", NullValueHandling = NullValueHandling.Ignore)] string Measure6,
    [property: JsonProperty("strMeasure7", NullValueHandling = NullValueHandling.Ignore)] string Measure7,
    [property: JsonProperty("strMeasure8", NullValueHandling = NullValueHandling.Ignore)] object Measure8,
    [property: JsonProperty("strMeasure9", NullValueHandling = NullValueHandling.Ignore)] object Measure9,
    [property: JsonProperty("strMeasure10", NullValueHandling = NullValueHandling.Ignore)] object Measure10,
    [property: JsonProperty("strMeasure11", NullValueHandling = NullValueHandling.Ignore)] object Measure11,
    [property: JsonProperty("strMeasure12", NullValueHandling = NullValueHandling.Ignore)] object Measure12,
    [property: JsonProperty("strMeasure13", NullValueHandling = NullValueHandling.Ignore)] object Measure13,
    [property: JsonProperty("strMeasure14", NullValueHandling = NullValueHandling.Ignore)] object Measure14,
    [property: JsonProperty("strMeasure15", NullValueHandling = NullValueHandling.Ignore)] object Measure15,
    [property: JsonProperty("strImageSource", NullValueHandling = NullValueHandling.Ignore)] string ImageSource,
    [property: JsonProperty("strImageAttribution", NullValueHandling = NullValueHandling.Ignore)] string ImageAttribution,
    [property: JsonProperty("strCreativeCommonsConfirmed", NullValueHandling = NullValueHandling.Ignore)] string CreativeCommonsConfirmed,
    [property: JsonProperty("dateModified", NullValueHandling = NullValueHandling.Ignore)] string DateModified)
{
    public override string ToString()
    {
        return Name;
    }
}

public record DrinkDetailResponse([property: JsonProperty("drinks", NullValueHandling = NullValueHandling.Ignore)] List<DrinkDetail> Drinks);
