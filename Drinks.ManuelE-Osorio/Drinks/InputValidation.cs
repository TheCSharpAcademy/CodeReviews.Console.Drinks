namespace DrinksProgram;

public class InputValidation
{
    public static string? ValidateCategoryName(CategoriesJSON? categories, string input)
    {
        string? errorMessage = null;

        if (categories!= null && !categories.Categories.Any(
            categories => categories.Category.Equals(input, StringComparison.OrdinalIgnoreCase)))
        {
            errorMessage = "The category you have entered does not exist. ";
        }

        return errorMessage;
    }

    public static string? ValidateDrinkID(DrinksByCategoryJSON? drinks, string input)
    {
        string? errorMessage = null;

        if (drinks != null && !drinks.Drinks.Any(
            categories => categories.ID.Equals(input, StringComparison.OrdinalIgnoreCase)))
        {
            errorMessage = "The ID you have entered does not exist. ";
        }

        return errorMessage;
    }
}