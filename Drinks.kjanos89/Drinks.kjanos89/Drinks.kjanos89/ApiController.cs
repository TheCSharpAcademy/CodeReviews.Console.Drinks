using Drinks.kjanos89.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Web;

namespace Drinks.kjanos89
{
    public class ApiController
    {
        public void GetCategories()
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);
            if(response.Result.StatusCode==System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);
                List<Category> categories = serialize.CategoryList;
                Menu.ShowData(categories, "Categories");

            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
        }

        internal void GetDrinks(string choice)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(choice)}");
            var response = client.ExecuteAsync(request);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<DrinksClass>(rawResponse);
                List<Drink> drinks = serialize.DrinkList;
                Menu.ShowData(drinks, "Drinks");

            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
        }
    }
}
