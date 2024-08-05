using Newtonsoft.Json;
using RestSharp;
using DrinksInfo.Arashi256.Models;
using System.Web;
using System.Collections.Generic;

namespace DrinksInfo.Arashi256.Classes
{
    internal class DrinksService
    {
        private const string _baseAPI = "http://www.thecocktaildb.com/api/json/v1/1/";

        public List<Category>? GetCategories()
        {
            var client = new RestClient(_baseAPI);
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);
                return serialize.CategoriesList;
            }
            else
                return null;
        }

        public List<Drink>? GetDrinksByCategory(string category)
        {
            var client = new RestClient(_baseAPI);
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);
                return serialize.DrinksList;
            }
            else
                return null;
        }

        public DrinkDetail? GetDrink(string drink)
        {
            var client = new RestClient(_baseAPI);
            var request = new RestRequest($"lookup.php?i={drink}");
            var response = client.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);
                List<DrinkDetail> returnedList = serialize.DrinkDetailList;
                DrinkDetail drinkDetail = returnedList[0];
                return drinkDetail;
            }
            else
                return null;
        }
    }
}
