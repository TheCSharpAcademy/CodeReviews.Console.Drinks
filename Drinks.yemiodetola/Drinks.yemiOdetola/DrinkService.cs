using Newtonsoft.Json;
using System.Web;
using Drinks.yemiOdetola.Models;


namespace Drinks.yemiOdetola;

public class DrinkService
{
  private readonly HttpClient httpClient;

  public DrinkService(HttpClient client)
  {
    httpClient = client;
  }

  public async Task<List<Category>> GetCategories()
  {
    List<Category> categories = new();
    string requestUrl = "list.php?c=list";

    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

    if (response.IsSuccessStatusCode)
    {
      string responseData = await response.Content.ReadAsStringAsync();
      var serialize = JsonConvert.DeserializeObject<Categories>(responseData);

      categories = serialize.CategoriesList;
      return categories;
    }
    else
    {
      return categories;
    }

  }

  public async Task<DrinkDetails> GetDrinkById(string drink)
  {
    string requestUrl = $"lookup.php?i={HttpUtility.UrlEncode(drink)}";
    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

    DrinkDetails drinkDetails = new DrinkDetails();

    if (response.IsSuccessStatusCode)
    {
      string responseData = await response.Content.ReadAsStringAsync();
      var serialize = JsonConvert.DeserializeObject<DrinkDetailsObject>(responseData);

      if (serialize == null)
      {
        return null;
      }
      else
      {
        List<DrinkDetails> serializedList = serialize.DrinkDetailsList;
        drinkDetails = serializedList[0];
        return drinkDetails;
      }
    }
    else
    {
      return drinkDetails;
    }

  }


  public async Task<List<Drink>> GetDrinksByCategory(string category)
  {
    List<Drink> drinks = new List<Drink>();
    string requestUrl = $"filter.php?c={HttpUtility.UrlEncode(category)}";
    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

    if (response.IsSuccessStatusCode)
    {
      string responseData = await response.Content.ReadAsStringAsync();
      var serialize = JsonConvert.DeserializeObject<DrinksList>(responseData);

      if (serialize == null)
      {
        return null;
      }
      else
      {
        drinks = serialize.DrinksListItems;
        return drinks;
      }
    }
    else
    {
      return null;
    }
  }

  internal async Task<DrinkDetails> GetRandomDrink()
  {
    string requestUrl = "random.php";
    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

    DrinkDetails drinkDetails = new DrinkDetails();

    if (response.IsSuccessStatusCode)
    {
      string responseData = await response.Content.ReadAsStringAsync();

      var serialize = JsonConvert.DeserializeObject<DrinkDetailsObject>(responseData);

      if (serialize == null)
      {
        return null;
      }
      else
      {
        List<DrinkDetails> serializedList = serialize.DrinkDetailsList;

        drinkDetails = serializedList[0];

        return drinkDetails;
      }
    }
    else
    {
      return null;
    }
  }


}
