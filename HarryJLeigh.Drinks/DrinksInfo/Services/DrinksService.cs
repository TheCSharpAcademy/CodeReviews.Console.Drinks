using DrinksInfo.Controllers;
using DrinksInfo.Models;
using DrinksInfo.Utilities;
using DrinksInfo.Views;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo.Services;

public class DrinksService
{
    private readonly DrinksController _drinksController = new DrinksController();

    internal void Run()
    {
        bool endApp = false;

        while (!endApp)
        {
            List<Category> categories = _drinksController.GetCategories();
            string selectedCategory = GetValidCategory(categories);

            List<Drink> drinks = _drinksController.GetDrinks(selectedCategory);
            int selectedDrinkId = GetValidDrinkId(drinks);
            
            _drinksController.GetIngredients(selectedDrinkId);
            endApp = Util.ReturnToMenu();
        }
    }


    private string GetValidCategory(List<Category> categories)
    {
        while (true)
        {
            string selectedCategory = Util.UserInput("Choose a category:");
            if (Validator.IsCategoryValid(categories, selectedCategory))
            {
                return selectedCategory;
            }

            Console.WriteLine("Invalid category. Please try again.");
        }
    }

    private int GetValidDrinkId(List<Drink> drinks)
    {
        int selectedDrinkId;
        do
        {
            string input = Util.UserInput("Select a drink ID:");
            if (!int.TryParse(input, out selectedDrinkId) || !Validator.IsDrinkValid(drinks, selectedDrinkId))
            {
                Console.WriteLine("Invalid drink ID. Please try again.");
            }
        } while (!Validator.IsDrinkValid(drinks, selectedDrinkId));

        return selectedDrinkId;
    }
}