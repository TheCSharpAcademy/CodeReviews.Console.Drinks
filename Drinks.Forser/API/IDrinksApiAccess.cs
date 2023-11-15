namespace Drinks.Forser
{
    internal interface IDrinksApiAccess
    {
        public Task<IEnumerable<Category>> GetCategories();
        public Task<IEnumerable<Drink>> GetDrinksByCategory(string category);
        public Task<DrinkDetails> GetDrinkById(int drinkId);
    }
}