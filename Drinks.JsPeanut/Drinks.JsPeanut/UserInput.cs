namespace Drinks.JsPeanut
{
    internal class UserInput
    {
        public static void GetCategoriesInput()
        {
            var categories = DrinksService.GetCategoriesList();

            Console.WriteLine("Select a category.");

            var category = Console.ReadLine();

            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("Invalid category");
                category = Console.ReadLine();
            }

            if (!categories.Any(x => x.strCategory == category))
            {
                Console.WriteLine("Category doesn't exist.");
                GetCategoriesInput();
            }

            GetDrinksInput(category);
        }

        private static void GetDrinksInput(string category)
        {
            var drinks = DrinksService.GetDrinksByCategory(category);

            Console.WriteLine("Choose a drink or go back to the main menu typing M");

            string drink = Console.ReadLine();

            if (drink == "M") GetCategoriesInput();

            while (!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid drink");
                drink = Console.ReadLine();
            }

            if (!drinks.Any(x => x.idDrink == drink))
            {
                Console.WriteLine("Drink doesn't exist.");
                GetDrinksInput(category);
            }

            DrinksService.GetDrink(drink);

            Console.WriteLine("Press any key to go back to categories menu");
            Console.ReadKey();
            if (!Console.KeyAvailable) GetCategoriesInput();
        }
    }
}
