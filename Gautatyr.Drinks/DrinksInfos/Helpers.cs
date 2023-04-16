using static DrinksInfos.ApiManager;

namespace DrinksInfos;

public static class Helpers
{
    public static void DisplayError(string error)
    {
        Console.WriteLine($"\n|---> Error: {error} <---|\n");
    }

    public static Categories[] GetSequencedCategoriesList()
    {
        var categories = GetCategoriesAsync();
        int id = 1;

        foreach (var category in categories)
        {
            category.Id = id;
            id++;
        }

        return categories;
    }

    public static Drink[] GetSequencedDrinkList(string categoryName)
    {
        var drinks = GetDrinksAsync(categoryName);
        int id = 1;

        foreach (var drink in drinks)
        {
            drink.Id = id.ToString();
            id++;
        }

        return drinks;
    }
}
