using RestSharp;

namespace Drinks.UgniusFalze;

public class DrinksService
{
    private string CocktailDb { get; set; }
    public DrinksService(string cocktailDbLink = "https://www.thecocktaildb.com/api/json/v1/1/")
    {
        CocktailDb = cocktailDbLink;
    }
    public Categories GetDrinkCategories()
    {
        var client = new RestClient(CocktailDb);
        var listType = new
        {
            c = "list"
        };

        var response = client.GetJson<Categories>("list.php", listType);
        return response ?? new Categories(new List<Category>());
    }

    public DrinksRecord GetDrinksRecord(Category category)
    {
        var client = new RestClient(CocktailDb);
        var categoryType = new
        {
            c = category.StrCategory
        };

        var response = client.GetJson<DrinksRecord>("filter.php", categoryType);
        return response ?? new DrinksRecord(new List<Drink>());
    }

    public DrinkDetailsRecord GetDrinkDetailsRecord(Drink drink)
    {
        var client = new RestClient(CocktailDb);
        var drinkId = new
        {
            i = drink.IdDrink
        };
        var response = client.GetJson<DrinkDetailsRecord>("lookup.php", drinkId);
        return response ?? new DrinkDetailsRecord(new List<DrinkDetails>());
    }
}