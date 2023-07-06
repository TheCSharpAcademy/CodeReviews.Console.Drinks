
using Newtonsoft.Json;

namespace kmakai.Drinks.Models;

public class DrinkDetailObject
{
    [JsonProperty("drinks")]
    public List<DrinkDetail> DrinkDetailList { get; set; }
}
public class DrinkDetail
{
    [JsonProperty("strDrink")]
    public string StrDrink { get; set; }
    [JsonProperty("strDrinkAlternate")]
    public object StrDrinkAlternate { get; set; }
    [JsonProperty("strTags")]
    public object StrTags { get; set; }
    [JsonProperty("strVideo")]
    public object StrVideo { get; set; }
    [JsonProperty("strCategory")]
    public string StrCategory { get; set; }
    [JsonProperty("strIBA")]
    public object StrIba { get; set; }
    [JsonProperty("strAlcoholic")]
    public string StrAlcoholic { get; set; }
    [JsonProperty("strGlass")]
    public string StrGlass { get; set; }
    [JsonProperty("strInstructions")]
    public string StrInstructions { get; set; }
    [JsonProperty("strInstructionsES")]
    public object StrInstructionsES { get; set; }
    [JsonProperty("strInstructionsDE")]
    public string StrInstructionsDE { get; set; }
    [JsonProperty("strInstructionsFR")]
    public object StrInstructionsFR { get; set; }
    [JsonProperty("strInstructionsIT")]
    public string StrInstructionsIT { get; set; }
    [JsonProperty("strInstructionsZH-HANS")]
    public object StrInstructionsZhhans { get; set; }
    [JsonProperty("strInstructionsZH-HANT")]
    public object StrInstructionsZhhant { get; set; }
    [JsonProperty("strDrinkThumb")]
    public string StrDrinkThumb { get; set; }
    [JsonProperty("strIngredient1")]
    public string StrIngredient1 { get; set; }
    [JsonProperty("strIngredient2")]
    public string StrIngredient2 { get; set; }
    [JsonProperty("strIngredient3")]
    public string StrIngredient3 { get; set; }
    [JsonProperty("strIngredient4")]
    public string StrIngredient4 { get; set; }
    [JsonProperty("strIngredient5")]
    public object StrIngredient5 { get; set; }
    [JsonProperty("strIngredient6")]
    public object StrIngredient6 { get; set; }
    [JsonProperty("strIngredient7")]
    public object StrIngredient7 { get; set; }
    [JsonProperty("strIngredient8")]
    public object StrIngredient8 { get; set; }
    [JsonProperty("strIngredient9")]
    public object StrIngredient9 { get; set; }
    [JsonProperty("strIngredient10")]
    public object StrIngredient10 { get; set; }
    [JsonProperty("strIngredient11")]
    public object StrIngredient11 { get; set; }
    [JsonProperty("strIngredient12")]
    public object StrIngredient12 { get; set; }
    [JsonProperty("strIngredient13")]
    public object StrIngredient13 { get; set; }
    [JsonProperty("strIngredient14")]
    public object StrIngredient14 { get; set; }
    [JsonProperty("strIngredient15")]
    public object StrIngredient15 { get; set; }
    [JsonProperty("strMeasure1")]
    public string StrMeasure1 { get; set; }
    [JsonProperty("strMeasure2")]
    public string StrMeasure2 { get; set; }
    [JsonProperty("strMeasure3")]
    public string StrMeasure3 { get; set; }
    [JsonProperty("strMeasure4")]
    public string StrMeasure4 { get; set; }
    [JsonProperty("strMeasure5")]
    public object StrMeasure5 { get; set; }
    [JsonProperty("strMeasure6")]
    public object StrMeasure6 { get; set; }
    [JsonProperty("strMeasure7")]
    public object StrMeasure7 { get; set; }
    [JsonProperty("strMeasure8")]
    public object StrMeasure8 { get; set; }
    [JsonProperty("strMeasure9")]
    public object StrMeasure9 { get; set; }
    [JsonProperty("strMeasure10")]
    public object StrMeasure10 { get; set; }
    [JsonProperty("strMeasure11")]
    public object StrMeasure11 { get; set; }
    [JsonProperty("strMeasure12")]
    public object StrMeasure12 { get; set; }
    [JsonProperty("strMeasure13")]
    public object StrMeasure13 { get; set; }
    [JsonProperty("strMeasure14")]
    public object StrMeasure14 { get; set; }
    [JsonProperty("strMeasure15")]
    public object StrMeasure15 { get; set; }
    [JsonProperty("strImageSource")]
    public object StrImageSource { get; set; }
    [JsonProperty("strImageAttribution")]
    public object StrImageAttribution { get; set; }
    [JsonProperty("strCreativeCommonsConfirmed")]
    public string StrCreativeCommonsConfirmed { get; set; }
    [JsonProperty("dateModified")]
    public string DateModified { get; set; }
}
