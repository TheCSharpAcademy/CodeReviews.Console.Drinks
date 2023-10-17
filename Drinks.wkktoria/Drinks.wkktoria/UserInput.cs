using Drinks.wkktoria.Services;

namespace Drinks.wkktoria;

internal class UserInput
{
    internal void GetCategoriesInput()
    {
        var categories = DrinksService.GetCategories();

        Console.Write("Choose category: ");

        var category = Console.ReadLine();

        while (!Validator.IsStringValid(category))
        {
            Console.WriteLine("Invalid category.");
            category = Console.ReadLine();
        }

        if (categories != null && !categories.Any(c =>
                c.StrCategory != null && c.StrCategory.Equals(category, StringComparison.InvariantCultureIgnoreCase)))
        {
            Console.WriteLine("Category doesn't exist.");
            Console.WriteLine("Press any key to return to categories menu...");
            Console.ReadKey();
            if (!Console.KeyAvailable) GetCategoriesInput();
        }

        if (category != null) GetDrinksInput(category);
    }

    private void GetDrinksInput(string category)
    {
        var drinks = DrinksService.GetDrinksByCategory(category);

        Console.Write("Choose a drink by choosing id or go back by entering '0': ");

        var id = Console.ReadLine();

        if (id == "0") GetCategoriesInput();

        while (!Validator.IsIdValid(id))
        {
            Console.Write("Invalid drink. Enter valid id: ");
            id = Console.ReadLine();
        }

        if (drinks != null && !drinks.Any(d =>
                d.IdDrink != null && d.IdDrink.Equals(id, StringComparison.InvariantCultureIgnoreCase)))
        {
            Console.WriteLine("Drink doesn't exist.");
            Console.WriteLine("Press any key to return to drinks menu...");
            Console.ReadKey();
            if (!Console.KeyAvailable) GetDrinksInput(category);
        }

        if (id != null) DrinksService.GetDrink(id);

        Console.WriteLine("Press any key to return to categories menu...");
        Console.ReadKey();
        if (!Console.KeyAvailable) GetCategoriesInput();
    }
}