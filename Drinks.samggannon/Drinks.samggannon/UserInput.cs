using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks.samggannon
{
    
    public class UserInput
    {
        DrinkService drinkService = new();

        internal void GetCategoriesINput()
        {
            var categories = drinkService.GetCategories();

            Console.WriteLine("Choose category");

            string category = Console.ReadLine();

            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("\nInvalid category");
                category = Console.ReadLine();
            }

            if(!categories.Any(x => x.strCategory == category))
            {
                Console.WriteLine("Category doesn't exist.");
                GetCategoriesINput();
            }

            GetDrinksInput(category);
        }

        private void GetDrinksInput(string? category)
        {
            var drinks = drinkService.GetDrinksByCategory(category);

            Console.WriteLine("Choose a drink or go back to category meny by typing 0:");

            string drink = Console.ReadLine();

            if (drink == "0") GetCategoriesINput();

            while (!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid drink");
                drink = Console.ReadLine();
            }

            if(!drinks.Any(x => x.idDrink == drink))
            {
                Console.WriteLine("Drink doesn't exist.");
                GetDrinksInput(category);
            }

            drinkService.GetDrink(drink);

            Console.WriteLine("Press any key to go back to categories menu");
            Console.ReadLine();
            if(Console.KeyAvailable)
            {
                GetCategoriesINput();
            }
        }
    }
}
