using DrinksInfo.Models;

namespace DrinksInfo.Controllers;

internal interface IDrinksController
{
    Task<IEnumerable<Category>> GetCategories();
    Task<DrinkDetailDto> GetDrinkInfoById(int drinkId);
    Task<IEnumerable<Drink>> GetDrinksByCategory(string category);
}