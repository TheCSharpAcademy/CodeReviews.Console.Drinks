using Drinks.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Drinks.Mappers;

/// <summary>
/// The DrinkMapper class is responsible for converting JSON objects to instances of the Drink class and vice versa.
/// </summary>
/// <remarks>
/// This class is used as a JsonConverter for the Drink class.
/// It implements the ReadJson method to convert a JSON object to a Drink instance,
/// and the WriteJson method to convert a Drink instance to a JSON object.
/// </remarks>
internal class DrinkMapper : JsonConverter<Drink>
    {
        private const string DrinkIdKey = "idDrink";
        private const string DrinkNameKey = "strDrink";
        private const string DrinkTagsKey = "strTags";
        private const string DrinkCategoryKey = "strCategory";
        private const string IsAlcoholicKey = "strAlcoholic";
        private const string DrinkGlassTypeKey = "strGlass";
        private const string DrinkInstructionsKey = "strInstructions";
        private const string DrinkImageKey = "strDrinkThumb";
        private const string IngredientKey = "strIngredient";
        private const string MeasureKey = "strMeasure";
        
        /// <summary>
        /// Reads a JSON object and converts it into an instance of the Drink class.
        /// </summary>
        /// <param name="reader">The JSON reader to read the object from.</param>
        /// <param name="objectType">The type of the object being read.</param>
        /// <param name="existingValue">The existing value of the object being read.</param>
        /// <param name="hasExistingValue">Indicates if an existing value exists for the object being read.</param>
        /// <param name="serializer">The JSON serializer.</param>
        /// <returns>The converted instance of the Drink class.</returns>
        public override Drink ReadJson(JsonReader reader, Type objectType, Drink? existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            var drink = new Drink
            {
                DrinkId = jObject[DrinkIdKey]?.ToString(),
                DrinkName = jObject[DrinkNameKey]?.ToString(),
                DrinkTags = jObject[DrinkTagsKey]?.ToString(),
                DrinkCategory = jObject[DrinkCategoryKey]?.ToString(),
                IsAlcoholic = jObject[IsAlcoholicKey]?.ToString(),
                DrinkGlassType = jObject[DrinkGlassTypeKey]?.ToString(),
                DrinkInstructions = jObject[DrinkInstructionsKey]?.ToString(),
                DrinkImage = jObject[DrinkImageKey]?.ToString()
            };

            drink.Ingredients = jObject.Properties()
                .Where(p => p.Name.StartsWith(IngredientKey) && !string.IsNullOrWhiteSpace(p.Value.ToString()))
                .Select(p => p.Value.ToString())
                .ToArray();

            drink.Measures = jObject.Properties()
                .Where(p => p.Name.StartsWith(MeasureKey) && !string.IsNullOrWhiteSpace(p.Value.ToString()))
                .Select(p => p.Value.ToString())
                .ToArray();
            
            return drink;
        }

        /// <summary>
        /// Writes an instance of the Drink class to a JSON writer.
        /// </summary>
        /// <param name="writer">The JSON writer to write the Drink instance to.</param>
        /// <param name="value">The Drink instance to write.</param>
        /// <param name="serializer">The JSON serializer.</param>
        public override void WriteJson(JsonWriter writer, Drink? value, JsonSerializer serializer)
        {
            JObject jObject = new JObject
            {
                { DrinkIdKey, value?.DrinkId },
                { DrinkNameKey, value?.DrinkName },
                { DrinkTagsKey, value?.DrinkTags },
                { DrinkCategoryKey, value?.DrinkCategory },
                { IsAlcoholicKey, value?.IsAlcoholic },
                { DrinkGlassTypeKey, value?.DrinkGlassType },
                { DrinkInstructionsKey, value?.DrinkInstructions },
                { DrinkImageKey, value?.DrinkImage }
            };
            
            if (value?.Ingredients != null)
            {
                for (int i = 0; i < value.Ingredients.Length; i++)
                {
                    string ingredientKey = $"{IngredientKey}{i + 1}";
                    jObject.Add(ingredientKey, value.Ingredients[i]);
                }
            }

            if (value?.Measures != null)
            {
                for (int i = 0; i < value.Measures.Length; i++)
                {
                    string measureKey = $"{MeasureKey}{i + 1}";
                    jObject.Add(measureKey, value.Measures[i]);
                }
            }
            
            jObject.WriteTo(writer);
        }
    }