namespace Drinks.MartinL_no.Models;

internal interface IDrinksDataAccess
{
    public Task<IEnumerable<Category>> GetCategories();

    public Task<IEnumerable<Drink>> GetDrinks(string categoryName);

    public Task<DrinkDetails> GetDrinkDetails(int drinkId);
}