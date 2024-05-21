using DrinksInfo.Models;

namespace DrinksInfo;
public interface IDrinksService
{
    Task<List<Category>> GetCategories();
    Task GetDrink(string drink);
    Task<List<Drink>> GetDrinksByCategory(string category);
}