using Newtonsoft.Json;

namespace DrinksInfo.Models
{
    public class DrinkDetail
    {
        public string IdDrink { get; set; }
        public string StrDrink { get; set; }
        public string StrDrinkAlternate { get; set; }
        public string StrTags { get; set; }
        public string StrVideo { get; set; }
        public string StrCategory { get; set; }
        public string StrIBA { get; set; }
        public string StrAlcoholic { get; set; }
        public string StrGlass { get; set; }
        public string StrInstructions { get; set; }
        public string StrInstructionsES { get; set; }
        public string StrInstructionsDE { get; set; }
        public string StrInstructionsFR { get; set; }
        public string StrInstructionsIT { get; set; }
        public string StrInstructionsZH_HANS { get; set; }
        public string StrInstructionsZH_HANT { get; set; }
        public string StrDrinkThumb { get; set; }
        public string StrIngredient1 { get; set; }
        public string StrIngredient2 { get; set; }
        public string StrIngredient3 { get; set; }
        public string StrIngredient4 { get; set; }
        public string StrIngredient5 { get; set; }
        public string StrIngredient6 { get; set; }
        public string StrIngredient7 { get; set; }
        public string StrIngredient8 { get; set; }
        public string StrIngredient9 { get; set; }
        public string StrIngredient10 { get; set; }
        public string StrIngredient11 { get; set; }
        public string StrIngredient12 { get; set; }
        public string StrIngredient13 { get; set; }
        public string StrIngredient14 { get; set; }
        public string StrIngredient15 { get; set; }
        public string StrMeasure1 { get; set; }
        public string StrMeasure2 { get; set; }
        public string StrMeasure3 { get; set; }
        public string StrMeasure4 { get; set; }
        public string StrMeasure5 { get; set; }
        public string StrMeasure6 { get; set; }
        public string StrMeasure7 { get; set; }
        public string StrMeasure8 { get; set; }
        public string StrMeasure9 { get; set; }
        public string StrMeasure10 { get; set; }
        public string StrMeasure11 { get; set; }
        public string StrMeasure12 { get; set; }
        public string StrMeasure13 { get; set; }
        public string StrMeasure14 { get; set; }
        public string StrMeasure15 { get; set; }
        public string StrImageSource { get; set; }
        public string StrImageAttribution { get; set; }
        public string StrCreativeCommonsConfirmed { get; set; }
        public string DateModified { get; set; }
    }

    public class DrinkDetailObject
    {
        [JsonProperty("drinks")]
        public List<DrinkDetail> DrinkDetailList { get; set; }
    }
}