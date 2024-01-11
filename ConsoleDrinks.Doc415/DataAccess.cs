using ConsoleDrinks.Doc415.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
namespace ConsoleDrinks.Doc415;

internal class DataAccess
{
    IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    private string BaseApiString;
    private string callCategory;
    private string getDrinkInformation;
    private string getCategoriesString;

    public DataAccess()
    {
        BaseApiString = configuration.GetSection("BaseApi")["BaseString"];
        callCategory = configuration.GetSection("Categories")["Category"];
        getDrinkInformation = configuration.GetSection("BaseApi")["GetDrinkInformation"];
        getCategoriesString = configuration.GetSection("BaseApi")["GetCategoriesString"];
    }

    internal async Task<List<CategoryDrink>> GetDrinksFromCategory(string category)
    {
        using HttpClient client = new HttpClient();
        string url = BaseApiString + callCategory + category;
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);


        HttpResponseMessage response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            var drinks = JsonConvert.DeserializeObject<CategoryDrinkList>(content);
            List<CategoryDrink> drinkList = drinks.drinks;

            return drinkList;
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            return null;
        }
    }

    internal async Task<List<Category>> GetCategories()
    {
        using HttpClient client = new HttpClient();
        string url = getCategoriesString;
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);


        HttpResponseMessage response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            var categoryList = JsonConvert.DeserializeObject<CategoryList>(content);
            List<Category> categories = categoryList.drinks;
            return categories;
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            return null;
        }
    }

    internal async Task<Drink> GetDrinkInformation(string _id)
    {
        using HttpClient client = new HttpClient();
        string url = getDrinkInformation + _id;

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        HttpResponseMessage response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            var drinkList = JsonConvert.DeserializeObject<DrinkList>(content);
            var drink = drinkList.drinks[0];
            return drink;
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            return null;
        }
    }
}
