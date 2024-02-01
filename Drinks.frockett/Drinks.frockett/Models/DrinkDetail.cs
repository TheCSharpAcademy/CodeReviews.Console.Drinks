using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Drinks.frockett.Models
{
    internal class DrinkDetailObject
    {
        [JsonProperty("drinks")]
        public List<DrinkDetail> DrinkDetailList { get; set; }
    }
    internal class DrinkDetail
    {
        public string StrDrink { get; set; }
        public object StrDrinkAlternate { get; set; }
        public object StrTags { get; set; }
        public object StrVideo { get; set; }
        public string StrCategory { get; set; }
        public object StrIBA { get; set; }
        public string StrAlcoholic { get; set; }
        public string StrGlass { get; set; }
        public string StrInstructions { get; set; }
        public object StrInstructionsES { get; set; }
        public string StrInstructionsDE { get; set; }
        public object StrInstructionsFR { get; set; }
        public string StrInstructionsIT { get; set; }
        public object StrInstructionsZHHANS { get; set; }
        public object StrInstructionsZHHANT { get; set; }
        public string StrDrinkThumb { get; set; }
        public string StrIngredient1 { get; set; }
        public string StrIngredient2 { get; set; }
        public string StrIngredient3 { get; set; }
        public string StrIngredient4 { get; set; }
        public object StrIngredient5 { get; set; }
        public object StrIngredient6 { get; set; }
        public object StrIngredient7 { get; set; }
        public object StrIngredient8 { get; set; }
        public object StrIngredient9 { get; set; }
        public object StrIngredient10 { get; set; }
        public object StrIngredient11 { get; set; }
        public object StrIngredient12 { get; set; }
        public object StrIngredient13 { get; set; }
        public object StrIngredient14 { get; set; }
        public object StrIngredient15 { get; set; }
        public string StrMeasure1 { get; set; }
        public string StrMeasure2 { get; set; }
        public string StrMeasure3 { get; set; }
        public string StrMeasure4 { get; set; }
        public object StrMeasure5 { get; set; }
        public object StrMeasure6 { get; set; }
        public object StrMeasure7 { get; set; }
        public object StrMeasure8 { get; set; }
        public object StrMeasure9 { get; set; }
        public object StrMeasure10 { get; set; }
        public object StrMeasure11 { get; set; }
        public object StrMeasure12 { get; set; }
        public object StrMeasure13 { get; set; }
        public object StrMeasure14 { get; set; }
        public object StrMeasure15 { get; set; }
        public object StrImageSource { get; set; }
        public object StrImageAttribution { get; set; }
        public string StrCreativeCommonsConfirmed { get; set; }
        public string DateModified { get; set; }


        // credit to mariusgrHiof for the idea to do this and this method to do it https://github.com/frockett/CodeReviews.Console.Drinks/blob/main/Drinks.mariusgrHiof/DrinksInfo/Drink.cs
        public string ConcatenateIngredients()
        {
            // Get all properties of the class
            PropertyInfo[] properties = GetType().GetProperties();

            // Filter properties that start with "strIngredient"
            var ingredientProperties = properties
                .Where(p => p.Name.StartsWith("StrIngredient"));


            // Get the values of the filtered properties
            var ingredientValues = ingredientProperties.Select(p => (string)p.GetValue(this, null));

            // Remove null or empty values
            ingredientValues = ingredientValues.Where(i => !string.IsNullOrEmpty(i));

            // Concatenate values with commas
            string result = string.Join(", ", ingredientValues);

            return result;
        }
    }



}
