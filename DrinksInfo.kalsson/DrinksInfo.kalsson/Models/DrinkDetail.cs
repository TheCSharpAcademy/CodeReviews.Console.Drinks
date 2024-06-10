using Newtonsoft.Json;

namespace DrinksInfo.kalsson.Models;

/// <summary>
/// Represents a detailed drink object.
/// </summary>
internal class DrinkDetailObject
    {
        [JsonProperty("drinks")]
        public List<DrinkDetail> DrinkDetailList { get; set; }
    }

internal class DrinkDetail
    {
        /// <summary>
        /// The name of the drink.
        /// </summary>
        public string strDrink { get; set; }
        public object strDrinkAlternate { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the drink.
        /// </summary>
        /// <remarks>
        /// These tags provide additional information or characteristics about the drink.
        /// They can be used to categorize drinks or provide specific details about ingredients, flavors, or preparation methods.
        /// </remarks>
        public object strTags { get; set; }

        /// <summary>
        /// The video related to the drink.
        /// </summary>
        public object strVideo { get; set; }

        /// <summary>
        /// Gets or sets the category of the drink.
        /// </summary>
        public string strCategory { get; set; }

        /// <summary>
        /// The International Bartenders Association (IBA) cocktail code for the drink.
        /// </summary>
        public object strIBA { get; set; }

        /// <summary>
        /// Gets or sets the alcoholic property of a drink detail.
        /// </summary>
        public string strAlcoholic { get; set; }

        /// <summary>
        /// Gets or sets the glass type for the drink.
        /// </summary>
        public string strGlass { get; set; }

        /// <summary>
        /// Gets or sets the instructions for preparing the drink.
        /// </summary>
        public string strInstructions { get; set; }

        /// <summary>
        /// Spanish instructions for preparing the drink.
        /// </summary>
        public object strInstructionsES { get; set; }

        /// <summary>
        /// Gets or sets the drink instructions in German.
        /// </summary>
        public string strInstructionsDE { get; set; }

        /// <summary>
        /// French instructions for preparing the drink.
        /// </summary>
        public object strInstructionsFR { get; set; }

        /// <summary>
        /// Gets or sets the Italian instructions for making the drink.
        /// </summary>
        public string strInstructionsIT { get; set; }

        /// <summary>
        /// The instructions for preparing the drink in Simplified Chinese (Hans).
        /// </summary>
        public object strInstructionsZHHANS { get; set; }

        /// <summary>
        /// Gets or sets the traditional Chinese instructions for the drink detail.
        /// </summary>
        public object strInstructionsZHHANT { get; set; }

        /// <summary>
        /// Gets or sets the drink thumbnail URL.
        /// </summary>
        public string strDrinkThumb { get; set; }

        /// <summary>
        /// Gets or sets the first ingredient of the drink.
        /// </summary>
        public string strIngredient1 { get; set; }

        /// <summary>
        /// Represents the second ingredient of a drink.
        /// </summary>
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }

        /// <summary>
        /// Gets or sets the fourth ingredient of the drink.
        /// </summary>
        public string strIngredient4 { get; set; }

        /// <summary>
        /// The fifth ingredient of a drink.
        /// </summary>
        public object strIngredient5 { get; set; }

        /// <summary>
        /// Gets or sets the sixth ingredient of a drink.
        /// </summary>
        public object strIngredient6 { get; set; }

        /// <summary>
        /// Gets or sets the seventh ingredient of a drink.
        /// </summary>
        public object strIngredient7 { get; set; }

        /// <summary>
        /// The eighth ingredient of the drink.
        /// </summary>
        public object strIngredient8 { get; set; }

        /// <summary>
        /// Gets or sets the ninth ingredient of a drink.
        /// </summary>
        public object strIngredient9 { get; set; }

        /// <summary>
        /// Gets or sets the tenth ingredient of a drink.
        /// </summary>
        public object strIngredient10 { get; set; }

        /// <summary>
        /// The 11th ingredient of a drink.
        /// </summary>
        public object strIngredient11 { get; set; }

        /// <summary>
        /// Gets or sets the ingredient at index 12 of a drink.
        /// </summary>
        public object strIngredient12 { get; set; }

        /// *Type**: object
        /// *Description**: This property represents the thirteenth ingredient of a drink.
        /// *Access**: Read/Write
        /// *Example Usage**:
        public object strIngredient13 { get; set; }

        /// <summary>
        /// Represents the fourteenth ingredient of a drink.
        /// </summary>
        public object strIngredient14 { get; set; }

        /// <summary>
        /// Gets or sets the 15th ingredient of a drink.
        /// </summary>
        public object strIngredient15 { get; set; }

        /// <summary>
        /// Gets or sets the measurement for the first ingredient in a drink recipe.
        /// </summary>
        public string strMeasure1 { get; set; }

        /// <summary>
        /// Represents the second measurement of the drink recipe.
        /// </summary>
        public string strMeasure2 { get; set; }

        /// <summary>
        /// Gets or sets the measurement amount or quantity of the third ingredient in a drink recipe.
        /// </summary>
        public string strMeasure3 { get; set; }

        /// <summary>
        /// Gets or sets the fourth measuring instruction for the drink.
        /// </summary>
        public string strMeasure4 { get; set; }

        /// <summary>
        /// Gets or sets the fifth measurement for a drink in the DrinkDetail object.
        /// </summary>
        /// <remarks>
        /// This property represents the fifth measurement for a drink and is part of the DrinkDetail object.
        /// </remarks>
        /// <value>
        /// The fifth measurement for a drink.
        /// </value>
        public object strMeasure5 { get; set; }

        /// <summary>
        /// Gets or sets the sixth measurement of the drink.
        /// </summary>
        public object strMeasure6 { get; set; }

        /// <summary>
        /// Represents the seventh measurement of the drink in the DrinkDetail object.
        /// </summary>
        /// <remarks>
        /// This property corresponds to the seventh ingredient measurement in the recipe
        /// of a drink. It is of type object and may contain a string value representing
        /// the measurement quantity or null if no measurement is available for the
        /// ingredient at this position in the recipe.
        /// </remarks>
        public object strMeasure7 { get; set; }

        /// <summary>
        /// Gets or sets the measurement for the eighth ingredient of a drink.
        /// </summary>
        public object strMeasure8 { get; set; }

        /// <summary>
        /// Gets or sets the measurement of the ninth ingredient in the drink detail.
        /// </summary>
        /// <value>
        /// The measurement of the ninth ingredient.
        /// </value>
        public object strMeasure9 { get; set; }

        /// <summary>
        /// Gets or sets the tenth measurement of the drink.
        /// </summary>
        public object strMeasure10 { get; set; }

        /// <summary>
        /// Gets or sets the measure for the eleventh ingredient of the drink.
        /// </summary>
        public object strMeasure11 { get; set; }

        /// <summary>
        /// The measurement for the twelfth ingredient in a drink recipe.
        /// </summary>
        public object strMeasure12 { get; set; }

        /// <summary>
        /// Gets or sets the 13th measurement of the drink.
        /// </summary>
        public object strMeasure13 { get; set; }

        /// <summary>
        /// Gets or sets the measurement for the 14th ingredient in a drink recipe.
        /// </summary>
        public object strMeasure14 { get; set; }

        /// <summary>
        /// Gets or sets the measure for the 15th ingredient in a drink recipe.
        /// </summary>
        public object strMeasure15 { get; set; }

        /// <summary>
        /// Gets or sets the image source of the drink.
        /// </summary>
        /// <value>
        /// The image source of the drink.
        /// </value>
        public object strImageSource { get; set; }

        /// <summary>
        /// The attribution information for the image of a drink.
        /// </summary>
        public object strImageAttribution { get; set; }

        /// <summary>
        /// Gets or sets the Creative Commons confirmation status for the drink.
        /// </summary>
        /// <value>
        /// The Creative Commons confirmation status for the drink.
        /// </value>
        public string strCreativeCommonsConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the drink detail was last modified.
        /// </summary>
        public string dateModified { get; set; }
    }