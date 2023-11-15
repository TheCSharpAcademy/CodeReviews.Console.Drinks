namespace Drinks.JsPeanut
{
    internal class UserInput
    {
        public static void GetCategoriesInput()
        {
            var categories = DrinksService.GetCategoriesList();

            Console.WriteLine("Welcome to Drinks App! Select a category. \n\nType 0 if you want exit the app.");

            var category = Console.ReadLine();

            if (category == "0")
            {
                Program.exitApp = true;
            }

            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("Invalid category");
                category = Console.ReadLine();
            }

            if (!categories.Any(x => x.StrCategory == category))
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

            if (!drinks.Any(x => x.IdDrink == drink))
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
