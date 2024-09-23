using System;
using System.Linq;

namespace drinks_info
{
    public class UserInput
    {
        DrinksService drinksService = new();
        Menu menu = new();

        internal void GetCategoriesInput()
        {
            var categories = drinksService.GetCategories();

            Console.WriteLine("Choose category, or type 0 to go back to the main menu");
            

            string category = Console.ReadLine();
            
            if(category == "0") menu.ShowMenu();

            else{
                while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("\nInvalid category");
                category = Console.ReadLine();
            }

            if(!categories.Any(x => x.strCategory == category)) 
            {
                Console.WriteLine("Category doesn't exist.");
                GetCategoriesInput();
            }
            
            GetDrinksInput(category);
            }

            
        }

        private void GetDrinksInput(string category)
        {
            var drinks = drinksService.GetDrinksByCategory(category);

            Console.WriteLine("Choose a drink or go back to category menu by typing 0:");

            string drink = Console.ReadLine();

            if (drink == "0") GetCategoriesInput();

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


            drinksService.GetDrink(drink);

            Console.WriteLine("Press any key to go back to categories menu");
            Console.ReadKey();
            if (!Console.KeyAvailable) GetCategoriesInput();

        }
    }
}