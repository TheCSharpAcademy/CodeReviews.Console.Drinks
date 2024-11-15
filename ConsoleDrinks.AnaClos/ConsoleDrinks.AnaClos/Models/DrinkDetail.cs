using Newtonsoft.Json;

namespace ConsoleDrinks.AnaClos.Models;

public class DrinkDetail
{
    [JsonProperty("idDrink")]
    public string IdDrink { get; set; }

    [JsonProperty("strDrink")]
    public string StrDrink { get; set; }

    [JsonProperty("strDrinkAlternate")]
    public string StrDrinkAlternate { get; set; }

    [JsonProperty("strTags")]
    public string StrTags { get; set; }

    [JsonProperty("strVideo")]
    public string StrVideo { get; set; }

    [JsonProperty("strCategory")]
    public string StrCategory { get; set; }

    [JsonProperty("strIBA")]
    public string StrIba { get; set; }

    [JsonProperty("strAlcoholic")]
    public string StrAlcoholic { get; set; }

    [JsonProperty("strGlass")]
    public string StrGlass { get; set; }

    [JsonProperty("strInstructions")]
    public string StrInstructions { get; set; }

    [JsonProperty("strInstructionsES")]
    public string StrInstructionsES { get; set; }

    [JsonProperty("strInstructionsDE")]
    public string StrInstructionsDE { get; set; }

    [JsonProperty("strInstructionsFR")]
    public string StrInstructionsFR { get; set; }

    [JsonProperty("strInstructionsIT")]
    public string StrInstructionsIT { get; set; }

    [JsonProperty("strInstructionsZHHANS")]
    public string StrInstructionsZhhans { get; set; }

    [JsonProperty("strInstructionsZHHANT")]
    public string StrInstructionsZhhant { get; set; }

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
    public string StrIngredient5 { get; set; }

    [JsonProperty("strIngredient6")]
    public string StrIngredient6 { get; set; }

    [JsonProperty("strIngredient7")]
    public string StrIngredient7 { get; set; }

    [JsonProperty("strIngredient8")]
    public string StrIngredient8 { get; set; }

    [JsonProperty("strIngredien9")]
    public string StrIngredient9 { get; set; }

    [JsonProperty("strIngredient10")]
    public string StrIngredient10 { get; set; }

    [JsonProperty("strIngredient11")]
    public string StrIngredient11 { get; set; }

    [JsonProperty("strIngredient12")]
    public string StrIngredient12 { get; set; }

    [JsonProperty("strIngredient13")]
    public string StrIngredient13 { get; set; }

    [JsonProperty("strIngredient14")]
    public string StrIngredient14 { get; set; }

    [JsonProperty("strIngredient15")]
    public string StrIngredient15 { get; set; }

    [JsonProperty("strMeasure1")]
    public string StrMeasure1 { get; set; }

    [JsonProperty("strMeasure2")]
    public string StrMeasure2 { get; set; }

    [JsonProperty("strMeasure3")]
    public string StrMeasure3 { get; set; }

    [JsonProperty("strMeasure4")]
    public string StrMeasure4 { get; set; }

    [JsonProperty("strMeasure5")]
    public string StrMeasure5 { get; set; }

    [JsonProperty("strMeasure6")]
    public string StrMeasure6 { get; set; }

    [JsonProperty("strMeasure7")]
    public string StrMeasure7 { get; set; }

    [JsonProperty("strMeasure8")]
    public string StrMeasure8 { get; set; }

    [JsonProperty("strMeasure9")]
    public string StrMeasure9 { get; set; }

    [JsonProperty("strMeasure10")]
    public string StrMeasure10 { get; set; }

    [JsonProperty("strMeasure11")]
    public string StrMeasure11 { get; set; }

    [JsonProperty("strMeasure12")]
    public string StrMeasure12 { get; set; }

    [JsonProperty("strMeasure13")]
    public string StrMeasure13 { get; set; }

    [JsonProperty("strMeasure14")]
    public string StrMeasure14 { get; set; }

    [JsonProperty("strMeasure15")]
    public string StrMeasure15 { get; set; }

    [JsonProperty("strImageSource")]
    public string StrImageSource { get; set; }

    [JsonProperty("strImageAttribution")]
    public string StrImageAttribution { get; set; }

    [JsonProperty("strCreativeCommonsConfirmed")]
    public string StrCreativeCommonsConfirmed { get; set; }

    [JsonProperty("dateModified")]
    public string DateModified { get; set; }
}

public class DrinksDetails
{
    [JsonProperty("drinks")]
    public List<DrinkDetail> DrinksList { get; set; }
}