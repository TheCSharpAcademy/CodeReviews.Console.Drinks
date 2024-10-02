class Program
{
    static async Task Main(string[] args)
    {
        DrinkService drinkService = new DrinkService();

        var categories = await drinkService.GetCategoriesAsync();
        ConsoleUI.DisplayCategories(categories);

        int categoryIndex = ConsoleUI.GetUserCategorySelection(categories.Count);
        var selectedCategory = categories[categoryIndex];

        var drinks = await drinkService.GetDrinksByCategoryAsync(selectedCategory.strCategory);

        if (drinks == null || drinks.Count == 0)
        {
            Console.WriteLine("No drinks found for the selected category.");
        }
        else
        {
            ConsoleUI.DisplayDrinks(drinks);
            int drinkIndex = ConsoleUI.GetUserDrinkSelection(drinks.Count);
            var selectedDrink = drinks[drinkIndex];

            var drinkDetails = await drinkService.GetDrinkDetailsAsync(selectedDrink.idDrink);
            ConsoleUI.DisplayDrinkDetails(drinkDetails);
        }
    }
}
