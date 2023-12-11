using DrinksInfo.Models;

internal interface IDrinksInfoClient
{
    Task<IEnumerable<Category>> GetCategories();
    Task<DrinkDetail> GetDrinkInfoById(int drinkId);
    Task<IEnumerable<Drink>> GetDrinksByCategory(string category);
}