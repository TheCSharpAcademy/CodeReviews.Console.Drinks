using CodingTracker;
using Spectre.Console;

namespace DrinksInfo;

public static class CategoryService
{
    public static async Task<string> GetCategoryFromUser()
    {
        bool continueRunning = true;
        string userCategory;

        AnsiConsole.Clear();
        DrinksCategoriesResponse categoriesResponse = await DrinksCategoriesController.GetDrinkCategories();
        ShowCategories(categoriesResponse);

        do
        {
            userCategory = AskForCategory();
            continueRunning = !ValidCategory(categoriesResponse, userCategory);
            if (continueRunning)
            {
                AnsiConsole.MarkupLine("[red]Invalid category. Please try again.[/]");
            }
        } while (continueRunning);

        return userCategory;
    }

    private static void ShowCategories(DrinksCategoriesResponse response)
    {
        OutputRenderer.ShowTable<DrinkCategory>(response.DrinkCategories, "Categories");
    }

    private static string AskForCategory()
    {
        TextPrompt<string> textPrompt = new TextPrompt<string>("Choose Category: ");
        return AnsiConsole.Prompt(textPrompt);
    }

    private static bool ValidCategory(DrinksCategoriesResponse response, string userCategory)
    {
        if (response.DrinkCategories == null || userCategory == null) return false;
        return response.DrinkCategories.Any(c => c.Name.Equals(userCategory, StringComparison.InvariantCultureIgnoreCase));
    }
}