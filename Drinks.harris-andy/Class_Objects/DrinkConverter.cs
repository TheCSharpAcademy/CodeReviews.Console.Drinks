using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DrinksInfo.Class_Objects;

public class DrinkConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Drink);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);
        var drink = new Drink
        {
            DrinkID = (int)jsonObject["idDrink"]!,
            StrDrink = (string)jsonObject["strDrink"]!,
            Glass = (string)jsonObject["strGlass"]!,
            Instructions = (string)jsonObject["strInstructions"]!
        };

        foreach (var property in jsonObject.Properties())
        {
            if (property.Name.StartsWith("strIngredient") && property.Value.Type == JTokenType.String)
                drink.Ingredients.Add((string?)property.Value);

            if (property.Name.StartsWith("strMeasure") && property.Value.Type == JTokenType.String)
                drink.Measures.Add((string?)property.Value);
        }
        return drink;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        throw new NotImplementedException("Writing JSON is not implemented for this converter.");
    }
}