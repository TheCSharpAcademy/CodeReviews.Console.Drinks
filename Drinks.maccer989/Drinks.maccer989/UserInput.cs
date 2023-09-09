using System;
using System.Linq;

namespace Drinks.maccer989
{
    public class UserInput
    {
        DrinkCategories drinksCategories = new();
        DrinkByCategories drinksByCategories = new();
        DrinkGet drinksGet = new();

        internal void GetCategoriesInput()
        {
            var categories = drinksCategories.GetCategories();

            Console.WriteLine("Choose category:");

            string category = Console.ReadLine();

            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("\nInvalid category");
                category = Console.ReadLine();
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
            var drinks = drinksByCategories.GetDrinksByCategory(category);

            Console.WriteLine("Choose a drink or go back to category menu by typing 0:");

            string drink = Console.ReadLine();

            if (drink == "0") GetCategoriesInput();

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


            drinksGet.GetDrink(drink);

            Console.WriteLine("Press any key to go back to categories menu");
            Console.ReadKey();
            if (!Console.KeyAvailable) GetCategoriesInput();

        }
    }
}
