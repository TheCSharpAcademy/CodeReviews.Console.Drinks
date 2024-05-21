using System.Text.Json.Serialization;

namespace DrinksInfo.Models;

public class DrinkDetailObject
{
    [JsonPropertyName("drinks")]
    public List<DrinkDetail> DrinkDetailList { get; set; }
}

public class DrinkDetail
{
    [JsonPropertyName("idDrink")]
    public string Id { get; set; }
    [JsonPropertyName("strDrink")]
    public string Drink { get; set; }
    [JsonPropertyName("strDrinkAlternate")]
    public object DrinkAlternate { get; set; }
    [JsonPropertyName("strTags")]
    public string Tags { get; set; }
    [JsonPropertyName("strVideo")]
    public object Video { get; set; }
    [JsonPropertyName("strCategory")]
    public string Category { get; set; }
    [JsonPropertyName("strIBA")]
    public string IBA { get; set; }
    [JsonPropertyName("strAlcoholic")]
    public string Alcoholic { get; set; }
    [JsonPropertyName("strGlass")]
    public string Glass { get; set; }
    [JsonPropertyName("strInstructions")]
    public string Instructions { get; set; }
    [JsonPropertyName("strDrinkThumb")]
    public string DrinkThumb { get; set; }
    [JsonPropertyName("strIngredient1")]
    public string Ingredient1 { get; set; }
    [JsonPropertyName("strIngredient2")]
    public string Ingredient2 { get; set; }
    [JsonPropertyName("strIngredient3")]
    public string Ingredient3 { get; set; }
    [JsonPropertyName("strIngredient4")]
    public string Ingredient4 { get; set; }
    [JsonPropertyName("strIngredient5")]
    public object Ingredient5 { get; set; }
    [JsonPropertyName("strIngredient6")]
    public object Ingredient6 { get; set; }
    [JsonPropertyName("strIngredient7")]
    public object Ingredient7 { get; set; }
    [JsonPropertyName("strIngredient8")]
    public object Ingredient8 { get; set; }
    [JsonPropertyName("strIngredient9")]
    public object Ingredient9 { get; set; }
    [JsonPropertyName("strIngredient10")]
    public object Ingredient10 { get; set; }
    [JsonPropertyName("strIngredient11")]
    public object Ingredient11 { get; set; }
    [JsonPropertyName("strIngredient12")]
    public object Ingredient12 { get; set; }
    [JsonPropertyName("strIngredient13")]
    public object Ingredient13 { get; set; }
    [JsonPropertyName("strIngredient14")]
    public object Ingredient14 { get; set; }
    [JsonPropertyName("strIngredient15")]
    public object Ingredient15 { get; set; }
    [JsonPropertyName("strMeasure1")]
    public string Measure1 { get; set; }
    [JsonPropertyName("strMeasure2")]
    public string Measure2 { get; set; }
    [JsonPropertyName("strMeasure3")]
    public string Measure3 { get; set; }
    [JsonPropertyName("strMeasure4")]
    public object Measure4 { get; set; }
    [JsonPropertyName("strMeasure5")]
    public object Measure5 { get; set; }
    [JsonPropertyName("strMeasure6")]
    public object Measure6 { get; set; }
    [JsonPropertyName("strMeasure7")]
    public object Measure7 { get; set; }
    [JsonPropertyName("strMeasure8")]
    public object Measure8 { get; set; }
    [JsonPropertyName("strMeasure9")]
    public object Measure9 { get; set; }
    [JsonPropertyName("strMeasure10")]
    public object Measure10 { get; set; }
    [JsonPropertyName("strMeasure11")]
    public object Measure11 { get; set; }
    [JsonPropertyName("strMeasure12")]
    public object Measure12 { get; set; }
    [JsonPropertyName("strMeasure13")]
    public object Measure13 { get; set; }
    [JsonPropertyName("strMeasure14")]
    public object Measure14 { get; set; }
    [JsonPropertyName("strMeasure15")]
    public object Measure15 { get; set; }
    [JsonPropertyName("strImageSource")]
    public string ImageSource { get; set; }
    [JsonPropertyName("strImageAttribution")]
    public string ImageAttribution { get; set; }
    [JsonPropertyName("strCreativeCommonsConfirmed")]
    public string CreativeCommonsConfirmed { get; set; }
    [JsonPropertyName("dateModified")]
    public string DateModified { get; set; }
}

