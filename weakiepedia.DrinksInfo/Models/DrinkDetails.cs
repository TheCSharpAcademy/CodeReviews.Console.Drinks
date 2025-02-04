using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class DrinkDetail
{
    [JsonProperty("strDrink")]
    public string DrinkName { get; set; }
    [JsonProperty("strCategory")]
    public string Category { get; set; }
    [JsonProperty("strAlcoholic")]
    public string Alcoholic { get; set; }
    [JsonProperty("strGlass")]
    public string Glass { get; set; }
    [JsonProperty("strInstructions")]
    public string Instructions { get; set; }
    [JsonProperty("strDrinkThumb")]
    public string ImageUrl { get; set; }
    [JsonProperty("strIngredient1")]
    public string FirstIngredient { get; set; }
    [JsonProperty("strIngredient2")]
    public string SecondIngredient { get; set; }
    [JsonProperty("strIngredient3")]
    public string ThirdIngredient { get; set; }
    [JsonProperty("strIngredient4")]
    public string FourthIngredient { get; set; }
    [JsonProperty("strIngredient5")]
    public string FifthIngredient { get; set; }
    [JsonProperty("strIngredient6")]
    public string SixthIngredient { get; set; }
    [JsonProperty("strIngredient7")]
    public string SeventhIngredient { get; set; }
    [JsonProperty("strIngredient8")]
    public string EighthIngredient { get; set; }
    [JsonProperty("strIngredient9")]
    public string NinthIngredient { get; set; }
    [JsonProperty("strIngredient10")]
    public string TenthIngredient { get; set; }
    [JsonProperty("strIngredient11")]
    public string EleventhIngredient { get; set; }
    [JsonProperty("strIngredient12")]
    public string TwelfthIngredient { get; set; }
    [JsonProperty("strIngredient13")]
    public string ThirteenthIngredient { get; set; }
    [JsonProperty("strIngredient14")]
    public string FourteenthIngredient { get; set; }
    [JsonProperty("strIngredient15")]
    public string FifteenthIngredient { get; set; }
    [JsonProperty("strMeasure1")]
    public string FirstIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure2")]
    public string SecondIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure3")]
    public string ThirdIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure4")]
    public string FourthIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure5")]
    public string FifthIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure6")]
    public string SixthIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure7")]
    public string SeventhIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure8")]
    public string EighthIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure9")]
    public string NinthIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure10")]
    public string TenthIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure11")]
    public string EleventhIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure12")]
    public string TwelfthIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure13")]
    public string ThirteenthIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure14")]
    public string FourteenthIngredientMeasurement { get; set; }
    [JsonProperty("strMeasure15")]
    public string FifteenthIngredientMeasurement { get; set; }
}

public class DrinkDetails
{
    [JsonProperty("drinks")]
    public List<DrinkDetail> DrinkDetailsList { get; set; }
}
