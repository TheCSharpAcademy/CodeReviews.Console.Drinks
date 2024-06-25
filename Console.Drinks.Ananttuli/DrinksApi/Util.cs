using System.Text.Json;

namespace DrinksApi;

public class Util
{
    public static T AssertNonNull<T>(T? item)
    {
        if (item == null)
        {
            throw new Exception("Missing value");
        }

        return item;
    }

    public static string? TryParseJsonStringOrNull(JsonElement element, string propertyName)
    {
        bool success = element.TryGetProperty(
            $"{propertyName}",
            out JsonElement value
        );

        if (success)
        {
            var cleanedValue = value.ToString().Trim();
            return cleanedValue.Length > 0 ? cleanedValue : null;
        }

        return null;
    }

    public static List<string> TryParseMultipleJsonValues(
        JsonElement element,
        string propertyName,
        int min = 1,
        int max = 5
    )
    {
        List<string> values = [];

        for (int i = min; i <= max; i++)
        {
            var value = TryParseJsonStringOrNull(element, $"{propertyName}{i}");

            if (value != null)
            {
                values.Add(value);
            }
        }

        return values;
    }
}