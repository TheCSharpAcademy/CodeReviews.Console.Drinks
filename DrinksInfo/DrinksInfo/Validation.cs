using DrinksInfo.Model;

namespace DrinksInfo;

internal class Validation
{

    internal static bool ValidInput(string userInput, List<Category> categories)
    {
        foreach (var category in categories)
        {
            if (userInput.Equals(category.Name, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    internal static bool ValidInput(string userInput, List<DrinkMenuItem> drinks)
    {
        foreach (var drink in drinks)
        {
            if (userInput.Equals(drink.ID, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

}
