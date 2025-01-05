using System.Reflection;

namespace DrinksInfo.Utilities;

internal class GetObjectPropertyValues
{
    internal Dictionary<string, string> RetrievePropertiesValues(object obj)
    {
        // Get all properties
        PropertyInfo[] properties = obj.GetType().GetProperties();

        // Dictionary for storing key value pairs
        var values = new Dictionary<string, string>();

        foreach (var property in properties)
        {
            var value = property.GetValue(obj)?.ToString();
            if (value == null)
            {
                values.Add(property.Name, "null");
            }
            else
            {
                values.Add(property.Name, value);
            }
        }
        return values;
    }
}