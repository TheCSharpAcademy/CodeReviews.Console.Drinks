class Program
{
    static async Task Main()
    {
        DrinkService drinkService = new DrinkService();

        while (true)
        {
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

            Console.WriteLine("\nDo you want to search for another drink? (y/n): ");
            string input = Console.ReadLine().ToLower();
            if (input != "y")
            {
                Console.WriteLine("Exiting program...");
                break;
            }
        }
    }
}
