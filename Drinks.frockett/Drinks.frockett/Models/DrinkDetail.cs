using Newtonsoft.Json;
using System.Reflection;

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
        public string StrAlcoholic { get; set; }
        public string StrGlass { get; set; }
        public string StrInstructions { get; set; }
        public object StrInstructionsES { get; set; }
        public string StrInstructionsDE { get; set; }
        public object StrInstructionsFR { get; set; }
        public string StrInstructionsIT { get; set; }
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


        // credit to mariusgrHiof for the idea to do this. I took his code and paired the measurements with ingredients https://github.com/frockett/CodeReviews.Console.Drinks/blob/main/Drinks.mariusgrHiof/DrinksInfo/Drink.cs
        public string ConcatenateIngredients()
        {
            // Get all properties of the class
            PropertyInfo[] properties = GetType().GetProperties();

            var ingredientProperties = properties
                .Where(p => p.Name.StartsWith("StrIngredient"));

            var measureProperties = properties
                .Where(p => p.Name.StartsWith("StrMeasure"));

            // Prepare a list to hold 'measurement ingredient' strings
            var ingredientMeasurePairs = new List<string>();

            // Iterate through the ingredient properties
            foreach (var ingredientProperty in ingredientProperties)
            {
                // Get the corresponding measure property by replacing "StrIngredient" with "StrMeasure"
                var measureProperty = measureProperties.FirstOrDefault(p => p.Name.Replace("StrMeasure", "") == ingredientProperty.Name.Replace("StrIngredient", ""));

                if (measureProperty != null)
                {
                    // get value of type obj, cast to string
                    string ingredient = (string)ingredientProperty.GetValue(this, null);
                    string measure = (string)measureProperty.GetValue(this, null);

                    // Only add if the ingredient isn't null/empty
                    if (!string.IsNullOrEmpty(ingredient))
                    {
                        string measureIngredientPair = (!string.IsNullOrEmpty(measure) ? measure + " " : "") + ingredient;
                        ingredientMeasurePairs.Add(measureIngredientPair);
                    }
                }
            }
            string result = string.Join(", ", ingredientMeasurePairs);

            return result;
        }
    }
}
