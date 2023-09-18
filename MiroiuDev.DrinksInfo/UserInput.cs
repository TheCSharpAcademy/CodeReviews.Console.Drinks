namespace MiroiuDev.DrinksInfo;

internal class UserInput
{
    private readonly DrinksService _drinksService = new();

    internal async Task GetCategoriesInput()
    {
        var categories = await _drinksService.GetCategoriesAsync();

        TableVisualisationEngine.ShowTable(categories, "Categories Menu");

        Console.WriteLine("Choose category:");

        string? category = Console.ReadLine();

        while (!Validator.IsStringValid(category))
        {
            Console.WriteLine("\nInvalid category");
            category = Console.ReadLine();
        }

        if (!categories.Any(x => x.Name == category))
        {
            Console.WriteLine("Category doesn't exist.");
            await GetCategoriesInput();
            return;
        }

        await GetDrinksInput(category!);
    }

    private async Task GetDrinksInput(string category)
    {
        var drinks = await _drinksService.GetDrinksByCategoryAsync(category);

        TableVisualisationEngine.ShowTable(drinks, "Drinks");

        Console.WriteLine("Choose a drink or go back to category menu by tapping 0:");

        string? drink = Console.ReadLine();

        if (drink == "0")
        {
            Console.Clear();
            await GetCategoriesInput();
            return;
        }

        while (!Validator.IsIdValid(drink))
        {
            Console.WriteLine("\nInvalid drink");
            drink = Console.ReadLine();
        }

        if (!drinks.Any(x => x.Id == drink))
        {
            Console.WriteLine("Drink doesn't exist.");
            await GetDrinksInput(category);
            return;
        }

        var drinkDetails = await _drinksService.GetDrinkAsync(drink!);

        TableVisualisationEngine.ShowTable(drinkDetails, "Drink Details");

        Console.WriteLine("Press any key to go back to categories menu.");
        Console.ReadKey();

        if (!Console.KeyAvailable) await GetCategoriesInput();
    }
}
