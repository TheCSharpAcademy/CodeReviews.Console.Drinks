using Drinks_Info.Controller;
using Drinks_Info.Models;

namespace Drinks_Info.UI;

internal class Menu
{
    internal static void Start()
    {
        string? categoryName;

        while(true)
        {
            var categories = ViewCategories();

            Console.WriteLine("Please enter category name or 0 to exit");
            categoryName = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(categoryName))
            { 
                Console.Clear();
                Console.WriteLine("Input cannot be empty, please Try again...");
                continue;
            }

            if (categoryName == "0")
                return;

            if (!categories.Any(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.Clear();
                Console.WriteLine("Category not found, please Try again...");
                continue;
            }

            break;
        }

        while(true)
        {
            var drinks = DrinksService.GetDrinks(categoryName);

            ViewDrinks(drinks);

            Console.WriteLine("Please enter drink id to view details or 0 to back");

            string? id = Console.ReadLine()?.Trim();

            if (id == "0")
            {
                Start();
                return;
            }

            if (!drinks.Any(d => d.Id.Equals(id))) 
            {
                Console.Clear();
                Console.WriteLine("Drink not found, please Try again...");
                continue;
            }
            
            if (string.IsNullOrEmpty(id))
            {
                Console.Clear();
                Console.WriteLine("Input cannot be empty, please Try again...");
                continue;
            }

            if (!int.TryParse(id, out int result))
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please Try again...");
                continue;
            }

            ViewDrinkDetails(id);
            
            Pause();

            continue;
        }
    }

    public static void Pause()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static List<Category> ViewCategories()
    {
        var categories = DrinksService.GetCategories();

        Console.Clear();
        Console.WriteLine("Categories:\n");

        foreach (var category in categories)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine($"| {category.Name,-22} |");
        }
        Console.WriteLine("--------------------------");

        return categories;
    }

    private static void ViewDrinks(List<Drink> drinks)
    {
        Console.Clear();
        Console.WriteLine("Drinks:\n");

        foreach (var drink in drinks)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"| {drink.Id,-7} | {drink.Name,-25} |");
        }
        Console.WriteLine("---------------------------------------");

    }

    private static List<DrinkDetailDto> ViewDrinkDetails(string drinkId)
    {
        var drinkDetails = DrinksService.GetDrinkDetails(drinkId);
        Console.Clear();
        Console.WriteLine($"Ingrediants:\n");
        foreach (var drink in drinkDetails)
        {
            Console.WriteLine($"{drink.Name,-20} : {drink.Details}");
        }

        return drinkDetails;
    }

}
