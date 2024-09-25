using drinksLibrary.Models;
using Spectre.Console;

namespace drinksLibrary;

public class UserInput
{
    static DrinksHttpClient service = new DrinksHttpClient();
    
    public static async Task<DrinkDetailObject> ShowDrinkDetails(int drinkId)
    {
        return await service.GetDrinkDetails(drinkId);
    }

    public static async Task<string> ChooseCategory()
    {
        Categories categories = await service.GetCategories();
        List<string> categoryNames = categories.CategoriesList.Select(c => c.Cat).ToList();
        return TableVisualizationEngine.ShowChoicesMenu(categoryNames, "Choose a category:");
    }
    
    public static async Task<(int, string)> ChooseDrink(string categoryName)
    {
        Drinks drinks = await service.GetDrinksFromCategory(categoryName);
        List<string> drinkNames = drinks.DrinkList.Select(d => d.DrinkName).ToList();
        string drinkChoice = TableVisualizationEngine.ShowChoicesMenu(drinkNames, "Choose a drink:");

        Drink? drink = drinks.DrinkList.Find(d => d.DrinkName.Equals(drinkChoice));
        if (drink is null)
        {
            throw new NullReferenceException(drinkChoice);
        }
        return (drink.DrinkId, drinkChoice);
    }

    public static bool ChooseToExit()
    {
        return AnsiConsole.Prompt(new TextPrompt<bool>("Do you want to exit?")
                        .AddChoice(true)
                        .AddChoice(false)
                        .DefaultValue(false)
                        .DefaultValueStyle(style: "yellow")
                        .WithConverter(choice => choice ? "yes" : "no"));
    }
 
}
