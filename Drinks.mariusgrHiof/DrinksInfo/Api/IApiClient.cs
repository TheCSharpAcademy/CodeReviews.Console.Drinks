namespace DrinksInfo.Api;

public interface IApiClient
{
    Task<IEnumerable<Category>> GetCategories();
    Task<IEnumerable<Drink>> GetDrinksByCategory(string category);
    // Todo: Change to DrinkDetails
    Task<Drink> GetDrinkDetailById(string id);


}

