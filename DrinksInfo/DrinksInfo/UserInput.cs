using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinksInfo.Models;

//Interacts with API
namespace DrinksInfo
{
    internal class UserInput
    {
        DrinksService drinksService = new();

        internal async Task GetCategoriesInput()
        {
            Console.Clear();
            await drinksService.GetCategories();
            Console.WriteLine("Choose category");

            string category = Console.ReadLine();
            List<Category> categories = await drinksService.GetCategoriesList();

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
            Console.Clear();
            GetDrinksInput(category);
        }

        private async Task GetDrinksInput(string category)
        {
            Console.Clear();
            await drinksService.GetDrinksByCategory(category);

            Console.WriteLine("Choose a drink or go back to category menu by typing 0");

            string? drink = Console.ReadLine();

            if(drink == "0"){GetCategoriesInput();}

            while (!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid Input\n");
                drink = Console.ReadLine();
            }

            List<Drink> drinks = await drinksService.GetDrinksList(drink);

            if (!drinks.Any(x => x.idDrink == drink))
            {
                Console.WriteLine("Drink doesn't exist.");
                GetDrinksInput(category);
            }

            drinksService.GetDrink(drink);


        }
    }
}
