using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo.API
{
    internal static class DrinkListApi
    {
        internal static List<Drink> GetDrinksList( string category )
        {
            var jsonClient = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={category}");

            var response = jsonClient.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {

                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                List<Drink> drinks = serialize.DrinksList;

                return drinks;
            }
            return null;
        }
    }
}
