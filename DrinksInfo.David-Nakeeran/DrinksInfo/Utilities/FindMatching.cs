using DrinksInfo.Models;

namespace DrinksInfo.Utilities;

internal class FindMatching()
{
    internal bool FindMatchingCategory(List<Category> categories, string? drinkCategorySelected)
    {
        foreach (var category in categories)
        {
            if (category.Name?.ToLower() == drinkCategorySelected?.ToLower().Trim())
            {
                return true;
            }
        }
        return false;
    }
}