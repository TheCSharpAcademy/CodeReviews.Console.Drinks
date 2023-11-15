namespace Drinks.K_MYR;

internal interface IApiAccess
{
    public Task<IEnumerable<Category>?> GetCategories();
    public Task<IEnumerable<Drink>?> GetDrinksByCategory(string category);
    public Task<DrinkDetail?> GetDrinkById(int drinkId);
}
