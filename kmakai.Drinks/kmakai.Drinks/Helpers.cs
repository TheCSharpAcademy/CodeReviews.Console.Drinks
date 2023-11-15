
using kmakai.Drinks.Models;
using System.Reflection;

namespace kmakai.Drinks;

public static class Helpers
{
    public static List<object> FormatDrinkDetails(DrinkDetail drinkDetail)
    {
        List<object> formattedDrinkDetail = new();
        string formattedName = "";

        foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
        {
            if (prop.Name.Contains("str"))
            {
                formattedName = prop.Name.Replace("str", "");
            }

            if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
            {
                formattedDrinkDetail.Add(new { Key = formattedName.Trim(), Value = prop.GetValue(drinkDetail) });
            }
        }

        return formattedDrinkDetail;
    }
}
