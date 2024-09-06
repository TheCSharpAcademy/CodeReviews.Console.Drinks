using CodingTracker;
using Spectre.Console;

namespace DrinksInfo;

public static class DrinksPerCategoryService
{
    public static async Task<string> GetDrikIdFromUser(string categoryName)
    {
        bool continueRunning = true;
        string userId;

        AnsiConsole.Clear();
        DrinksPerCategoryResponse drinksResponse = await DrinksPerCategoryController.GetDrinksPerCategory(categoryName);
        ShowDrinks(drinksResponse);

        do
        {
            userId = AskForDrinkId();

            continueRunning = !ValidDrinkId(drinksResponse, userId);
            if (continueRunning)
            {
                AnsiConsole.MarkupLine("[red]Invalid Id. Please try again.[/]");
            }
        } while (continueRunning);

        return userId;
    }

    private static void ShowDrinks(DrinksPerCategoryResponse response)
    {
        OutputRenderer.ShowTable<Drink>(response.Drinks, "Drinks");
    }

    private static string AskForDrinkId()
    {
        TextPrompt<string> textPrompt = new TextPrompt<string>("Choose Drink Id or go back to categories by typing 0: ");
        return AnsiConsole.Prompt(textPrompt);
    }

    private static bool ValidDrinkId(DrinksPerCategoryResponse response, string userId)
    {
        if (response.Drinks == null || userId == null) return false;
        return (response.Drinks.Any(d => d.Id.Equals(userId, StringComparison.InvariantCultureIgnoreCase)) || userId == "0");
    }
}