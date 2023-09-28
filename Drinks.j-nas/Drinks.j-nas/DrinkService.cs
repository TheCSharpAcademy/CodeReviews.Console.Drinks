using System.Web;
using Drinks.j_nas.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Drinks.j_nas
{
    internal static class DrinkService
    {

        public static List<Category> GetCategories()
        {
            using var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
            var response = client.ExecuteAsync(new RestRequest());

            List<Category> categories = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                categories = serialize.CategoriesList;
                return categories;
            }

            return categories;


        }




        public static List<Drink> GetDrinksByCategory(string category)
        {
            using var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");

            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);

            List<Drink> drinks = new();

            
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<DrinkList>(rawResponse);

                drinks = serialize.Drinks;
                return drinks;
            }

            return drinks;
        }

        public static DrinkDetail GetDrinkById(string id)
        {
            using var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={HttpUtility.UrlEncode(id)}");
            var response = client.ExecuteAsync(request);

            DrinkDetail drink = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize =
                    JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);
                List<DrinkDetail> returnedList = serialize.DrinkDetailList;
                drink = returnedList[0];
                return drink;
            }

            return drink;
        }


        public static IEnumerable<Drink> SearchDrinks(string search)
        {
           using var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
           
                       var request = new RestRequest($"search.php?s={HttpUtility.UrlEncode(search)}");
                       var response = client.ExecuteAsync(request);
           
                       List<Drink> drinks = new();
           
                       
                       if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                       {
                           string rawResponse = response.Result.Content;
                           var serialize = JsonConvert.DeserializeObject<DrinkList>(rawResponse);
           
                           drinks = serialize.Drinks;
                           return drinks;
                       }
           
                       return drinks;
        }
    }
}
