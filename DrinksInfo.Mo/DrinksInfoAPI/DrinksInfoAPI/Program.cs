class Program
{
    static async Task Main()
    {
        DrinkService drinkService = new DrinkService();

        var categories = await drinkService.GetCategoriesAsync();

        if (categories == null || categories.Count == 0)
        {
            Console.WriteLine("No categories available.");
            return;
        }

        ConsoleUI.DisplayCategories(categories);

        int categoryIndex = ConsoleUI.GetUserCategorySelection(categories.Count);
        var selectedCategory = categories[categoryIndex];

        var drinks = await drinkService.GetDrinksByCategoryAsync(selectedCategory.StrCategory);

        if (drinks == null || drinks.Count == 0)
        {
            Console.WriteLine("No drinks found for the selected category.");
        }
        else
        {
            ConsoleUI.DisplayDrinks(drinks);
            int drinkIndex = ConsoleUI.GetUserDrinkSelection(drinks.Count);
            var selectedDrink = drinks[drinkIndex];

            var drinkDetails = await drinkService.GetDrinkDetailsAsync(selectedDrink.IdDrink);
            ConsoleUI.DisplayDrinkDetails(drinkDetails);
        }
    }
}
