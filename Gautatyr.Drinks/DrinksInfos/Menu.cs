using static DrinksInfos.Helpers;
using ConsoleTableExt;
using static DrinksInfos.DataValidation;
using static DrinksInfos.ApiManager;

namespace DrinksInfos;

public static class Menu
{
    public static void DrinksCategoriesMenu(string message = "")
    {
        Console.Clear();

        Console.WriteLine(message);

        var categories = GetSequencedCategoriesList();

        ConsoleTableBuilder
            .From(categories.ToList())
            .WithColumn("CATEGORIES:", "ID")
            .ExportAndWriteLine();

        int choice = GetCategoryIdInput("\nEnter the ID of the category of your drink:\n");

        Categories chosenCategory = null;

        foreach (Categories category in categories)
        {
            if (category.Id == choice) chosenCategory = category;
        }

        DrinksMenu(chosenCategory);
    }

    private static async void DrinksMenu(Categories category)
    {
        Console.Clear();

        Console.WriteLine($"\n{category.CategoryName.ToUpper()}\n");

        var drinks = GetSequencedDrinkList(category.CategoryName);

        ConsoleTableBuilder
            .From(drinks.ToList())
            .ExportAndWriteLine();

        Console.WriteLine($"\nType the id of the drink of your choice, or type 0 to go back.\n");

        int choice = GetDrinkIdInput(category.CategoryName);

        while (choice != 0)
        {
            Drink chosenDrink = null;

            foreach (Drink drink in drinks)
            {
                if (int.Parse(drink.Id) == choice) chosenDrink = drink;
            }

            DrinkDetailsMenu(chosenDrink);

            Console.Clear();

            ConsoleTableBuilder
                .From(drinks.ToList())
                .ExportAndWriteLine();

            Console.WriteLine($"\nType the id of the drink of your choice, or type 0 to go back.\n");
            choice = GetDrinkIdInput(category.CategoryName);
        }

        DrinksCategoriesMenu();
    }

    private static void DrinkDetailsMenu(Drink drink)
    {
        Console.Clear();

        var drinkInfos = GetDrinkInfoAsync(drink.DrinkName);

        Console.WriteLine($"\nMAIN INFORMATIONS:\n");
        ConsoleTableBuilder
            .From(drinkInfos[0].MainInfos())
            .ExportAndWriteLine();

        Console.WriteLine($"\nINSTRUCTIONS:\n");
        Console.WriteLine($"\n{drinkInfos[0].GetInstructions()}\n");

        Console.WriteLine($"\nINGREDIENTS:\n");
        ConsoleTableBuilder
            .From(drinkInfos[0].GetIngredients())
            .ExportAndWriteLine();

        Console.WriteLine($"\nPress enter to go back.\n");
        Console.ReadLine();
    }
}
