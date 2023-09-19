namespace Drinks;

using TheCocktailDb;

class MainController
{
    private readonly ApiClient apiClient; 

    public MainController(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public void ShowDrinkCategories()
    {
        var categories = apiClient.GetCategoriesAsync().Result;
        var view = new DrinkCategoriesView(this, categories);
        view.Show();
    }

    public void ShowDrinksOfCategory(CategoryDto category)
    {
        var drinks = apiClient.GetDrinksByCategoryAsync(category.Name).Result;
        var view = new DrinkListView(this, category, drinks);
        view.Show();
                   
    }

    public void ShowDrinkDetails(CategoryDto category, int drinkId)
    {
        var drink = apiClient.GetDrinkByIdAsync(drinkId).Result;
        var view = new DrinkDetailView(this, category, drink);
        view.Show();
    }

    public static void ShowExit()
    {
        var view = new ExitView();
        view.Show();
    }
}