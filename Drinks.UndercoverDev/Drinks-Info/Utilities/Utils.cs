using Drinks_Info.Models;

namespace Drinks_Info.Utilities
{
    public class Utils
    {
        public static List<PropertyItem> FormatPropertyName(DrinkDetails drinkDetails)
        {
            List<PropertyItem> propList = [];
            string formattedName = "";

            foreach (var prop in drinkDetails.GetType().GetProperties())
            {
                if (prop.Name.Contains("Str"))
                {
                    formattedName = prop.Name[3..];
                }

                var value = prop.GetValue(drinkDetails)?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    propList.Add(new PropertyItem
                    {
                        Key = formattedName,
                        Value = value
                    });
                }
            }

            return propList;
        }

        public static string GetUserResponse()
        {
            ConsoleHelper.PrintMessage("[green]Enter response: [/]");
            return Console.ReadLine()?? "";
        }
    }
}