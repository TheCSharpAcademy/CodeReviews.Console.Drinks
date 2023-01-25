using DrinksInfo.Models;

namespace DrinksInfo;

internal class UserInput
{
    readonly DrinksService drinksService = new();

    public string GetCategory()
    {
        List<Category> categories = drinksService.GetCategories();
        Console.WriteLine("Choose a category or type '0' to exit:");
        string category = Console.ReadLine();
        if (category == "0") { return "0"; }
        while (!Validator.IsStringValid(category))
        {
            Console.WriteLine("\nInvalid category");
            category = Console.ReadLine();
        }

        if (!categories.Select(x => x.strCategory).Contains(category))
        {
            Console.WriteLine("\nNo category of this name found.");
            GetCategory();
        }

        return category;
    }

    public string GetDrinkId(string? category)
    {
        List<Drink> drinks = drinksService.GetDrinksByCategory(category);
        Console.WriteLine("Choose a drink to its details or to return to the menu type '-1':");
        string drinkId = Console.ReadLine();
        if (drinkId == "-1") { return null; }
        while (!Validator.IsIdValid(drinkId))
        {
            Console.WriteLine("\nInvalid drink ID");
            drinkId = Console.ReadLine();
        }
        if (!drinks.Select(x => x.idDrink).Contains(drinkId))
        {
            Console.WriteLine("\nNo drink exists with this ID.");
            GetDrinkId(category);
        }

        return drinkId;
    }

    internal string GetOption()
    {
        Console.WriteLine("Type '0' to exit or '1' to return to main menu.");
        string option = Console.ReadLine();
        while (!Validator.IsValidOption(option))
        {
            Console.WriteLine("This is not a valid option, please type either '0' to exit or '1' to return to main menu.");
            option = Console.ReadLine();
        }
        return option;
    }
}
