using Newtonsoft.Json;
using Drinks.frockett.Models;
using System.Web;

namespace Drinks.frockett;

public class DrinksService
{
    private readonly HttpClient _httpClient;

    public DrinksService(HttpClient client)
    {
        _httpClient = client;
    } 

    public async Task<List<Category>> GetCategories()
    {
        List<Category> categories = new();

        string requestUri = "list.php?c=list";
        HttpResponseMessage response = await _httpClient.GetAsync(requestUri);

        if (response.IsSuccessStatusCode)
        {
            string rawResponse = await response.Content.ReadAsStringAsync();
            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

            categories = serialize.CategoriesList;

            return categories;
        }
        else
        {
            return categories;
        }
    }

    internal async Task<DrinkDetail> GetDrinkById(string drink)
    {
        string requestUri = $"lookup.php?i={HttpUtility.UrlEncode(drink)}";
        HttpResponseMessage response = await _httpClient.GetAsync(requestUri);

        DrinkDetail drinkDetail = new();

        if (response.IsSuccessStatusCode)
        {
            string rawResponse = await response.Content.ReadAsStringAsync();

            var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

            // make sure there is content. If no content, return null so that UserInput can tell the user
            if (serialize == null) return null;
            else
            {
                List<DrinkDetail> returnedList = serialize.DrinkDetailList;

                drinkDetail = returnedList[0];

                return drinkDetail;
            }
        }
        else return null;
    }

    internal async Task<List<Drink>> GetDrinksByCategory(string category)
    {
        List<Drink> drinks = new();

        string requestUri = $"filter.php?c={HttpUtility.UrlEncode(category)}";
        HttpResponseMessage response = await _httpClient.GetAsync(requestUri);

        if (response.IsSuccessStatusCode)
        {
            string rawResponse = await response.Content.ReadAsStringAsync();
            var serialize = JsonConvert.DeserializeObject<DrinksL>(rawResponse);

            // make sure there is content. If no content, return null so that UserInput can tell the user
            if (serialize == null) return null;
            else
            {
                //if there is content, return list
                drinks = serialize.DrinksList;
                return drinks;
            }
        }
        else return null;
    }

    internal async Task<DrinkDetail> GetRandomDrink()
    {
        string requestUri = "random.php";
        HttpResponseMessage response = await _httpClient.GetAsync(requestUri);

        DrinkDetail drinkDetail = new();

        if (response.IsSuccessStatusCode)
        {
            string rawResponse = await response.Content.ReadAsStringAsync();

            var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

            if (serialize == null) return null;
            else
            {
                List<DrinkDetail> returnedList = serialize.DrinkDetailList;

                drinkDetail = returnedList[0];

                return drinkDetail;
            }
        }
        else return null;
    }
}
