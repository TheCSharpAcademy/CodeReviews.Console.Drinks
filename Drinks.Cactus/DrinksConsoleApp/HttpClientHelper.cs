using DrinksConsoleApp.DataModel;
using Newtonsoft.Json.Linq;
namespace DrinksConsoleApp;

public class HttpClientHelper
{
    public static async Task<List<Category>> GetDrinkCategoriesAsync()
    {
        using (HttpClient client = new())
        {
            var json = await client.GetStringAsync(
                "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
            JObject data = JObject.Parse(json);
            var categories = data["drinks"].ToObject<List<Category>>();
            return categories;
        }
    }

    public static async Task<DrinkDetail> GetDrinkDetailAsync(int id)
    {
        using (HttpClient client = new())
        {
            var json = await client.GetStringAsync(
                $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}");
            JObject data = JObject.Parse(json);
            var drinkDetail = data["drinks"].ToObject<List<DrinkDetail>>()[0];
            return drinkDetail;
        }
    }

    public static async Task<List<Drink>> GetDrinksAsync(string cName)
    {
        using (HttpClient client = new())
        {
            var json = await client.GetStringAsync(
                $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={cName}");
            JObject data = JObject.Parse(json);
            var drinks = data["drinks"].ToObject<List<Drink>>();
            return drinks;
        }
    }
}
