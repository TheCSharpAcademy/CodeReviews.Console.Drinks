namespace Drinks.Ramseis
{
    public class UserInput
    {
        DrinksService drinksService = new();

        internal void GetCategoriesInput()
        {
            List<Category> categories = drinksService.GetCategories();

            Console.WriteLine("Choose a category:");
            string category = (Console.ReadLine() ?? "").Trim();

            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("\nInvalid category");
                category = (Console.ReadLine() ?? "").Trim();
            }

            if (!categories.Any(x => x.strCategory == category))
            {
                Console.WriteLine("Category doesn't exist.");
                GetCategoriesInput();
            }

            GetDrinksInput(category);
        }

        private void GetDrinksInput(string category)
        {
            List<Drink> drinks = drinksService.GetDrinksByCategory(category);

            Console.WriteLine("Choose a drink or go back to category menu by typing 0:");
            string drink = (Console.ReadLine() ?? "").Trim();

            if (drink == "0") { GetCategoriesInput(); }

            while (!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid drink");
                category = (Console.ReadLine() ?? "").Trim();
            }

            if (!drinks.Any(x => x.idDrink == drink))
            {
                Console.WriteLine("Drink doesn't exist.");
                GetDrinksInput(category);
            }


            drinksService.GetDrink(drink);

            Console.WriteLine("Press any key to go back to categories menu");
            Console.ReadKey();
            if (!Console.KeyAvailable) GetCategoriesInput();
        }
    }
}
