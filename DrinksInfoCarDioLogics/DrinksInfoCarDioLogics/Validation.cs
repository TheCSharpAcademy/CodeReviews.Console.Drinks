using DrinksInfoCarDioLogics.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Web;

namespace DrinksInfoCarDioLogics;

public class Validation
{
    public bool IsCategoryValid(string categoryChosen)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(categoryChosen)}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

            if (serialize != null)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid category!");
                Console.ReadLine();
                return false;
            }
        }
        else
        { 
            return false; 
        }
    }

    public bool IsDrinkValid(string drinkChosen)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"lookup.php?i={drinkChosen}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

            if (serialize != null)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid categoryasdasdasdasda!");
                Console.ReadLine();
                return false;
            }
        }
        else { return false; }
    }
}
