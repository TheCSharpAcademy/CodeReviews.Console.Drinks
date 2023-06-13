using LucianoNicolasArrieta.DrinksApp.Models;
using LucianoNicolasArrieta.DrinksApp.Services;

namespace LucianoNicolasArrieta.DrinksApp
{
    public class Menu
    {
        DrinksService drinksService = new DrinksService();
        Validator validator = new Validator();

        public void RunCategoriesMenu()
        {
            bool exit = false;
            string user_input;

            List<Category> categories = drinksService.GetCategories();

            Console.Write("\nChoose a Category or type 0 to exit: ");
            user_input = Console.ReadLine().Trim();

            while (!validator.ValidateCategory(categories, user_input))
            {
                Console.Write("\nThe category doesn't exist, please try again: ");
                user_input = Console.ReadLine().Trim();
            }

            if (user_input == "0")
            {
                exit = true;
                Console.WriteLine("See you!");
                Environment.Exit(0);
            } else
            {
                RunDrinksMenu(user_input);
            }
        }

        private void RunDrinksMenu(string category)
        {
            string user_input;

            List<Drink> drinks = drinksService.GetDrinksByCategory(category);

            Console.Write("\nType a Drink id or 0 to return: ");
            user_input = Console.ReadLine().Trim();

            while (!validator.ValidateDrink(drinks, user_input))
            {
                Console.Write("\nThe drink id doesn't exist, please try again: ");
                user_input = Console.ReadLine().Trim();
            }

            if (user_input == "0")
            {
                RunCategoriesMenu();
            }
            else
            {
                Console.Clear();
                drinksService.GetDrinkDetail(user_input);
                Console.WriteLine("\nPress any button to go back to categories menu");
                Console.ReadKey();
                RunCategoriesMenu();
            }
        }
    }
}