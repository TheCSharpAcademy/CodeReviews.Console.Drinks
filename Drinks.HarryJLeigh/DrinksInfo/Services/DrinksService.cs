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
            string selectedCategory = UserInput.ChooseCategory(categories);

            List<Drink> drinks = _drinksController.GetDrinks(selectedCategory);
            int selectedDrinkId = UserInput.ChooseDrink(drinks);
            
            _drinksController.GetDrinkData(selectedDrinkId);
            endApp = Util.ReturnToMenu();
        }
    }
}