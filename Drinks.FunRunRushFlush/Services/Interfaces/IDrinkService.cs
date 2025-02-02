using Drinks.FunRunRushFlush.Data.Model;

namespace Drinks.FunRunRushFlush.Services.Interfaces
{
    public interface IDrinkService
    {
        Task<DrinksResponse?> ShowAllCategoryAsync();
        Task<DrinksResponse?> ShowAllDrinksFromCategoryAsync(string selection);
        Task<DrinksResponse?> ShowDrinkInfoForIdAsync(string selection);
    }
}