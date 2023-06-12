using LucianoNicolasArrieta.Drinks.Models;
using LucianoNicolasArrieta.Drinks.Services;

namespace LucianoNicolasArrieta.Drinks
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

            Console.Write("\nChoose a category: ");
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
                Console.WriteLine($"YOU CHOOSE: {user_input}");
            }
        }
    }
}
