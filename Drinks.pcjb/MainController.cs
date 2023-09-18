namespace Drinks;

using TheCocktailDb;

class MainController
{
    private ApiClient apiClient; 

    public MainController(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public async void ShowDrinkCategories()
    {
        var categories = await apiClient.GetCategoriesAsync();
        var view = new DrinkCategoriesView(this, categories);
        view.Show();
    }

    public async void ShowDrinksOfCategory(Category category)
    {
        var drinks = await apiClient.GetDrinksByCategoryAsync(category.Name);
        var view = new DrinkListView(this, category, drinks);
        view.Show();
                   
    }

    public async void ShowDrinkDetails(Category category, int drinkId)
    {
        var drink = await apiClient.GetDrinkByIdAsync(drinkId);
        var view = new DrinkDetailView(this, category, drink);
        view.Show();
    }
}