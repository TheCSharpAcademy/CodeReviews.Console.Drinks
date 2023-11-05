using System.Net;
using Drinks.barakisbrown.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Drinks.barakisbrown
{
    public static class DrinksService
    {
        private static readonly string clientStr = "http://www.thecocktaildb.com/api/json/v1/1";
        public static IEnumerable<Category> GetCategories()
        {
            var client = new RestClient(clientStr);
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == HttpStatusCode.OK)
            {
                var rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);
                return serialize.CategoriesList;
            }

            return Enumerable.Empty<Category>();
        }

        public static IEnumerable<Drink> GetDrinkList(Category category)
        {
            var requestStr = $"filter.php?c={category.strCategory}";

            var client = new RestClient(clientStr);
            var request = new RestRequest(requestStr);
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == HttpStatusCode.OK)
            {
                var rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Models.Drinks>(rawResponse);
                return serialize.DrinksList;
            }

            return Enumerable.Empty<Drink>();
        }

        public static IEnumerable<DrinkDetail> GetDrink(Drink drink)
        {
            var client = new RestClient(clientStr);
            var request = new RestRequest($"search.php?s={drink.StrDrink}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == HttpStatusCode.OK)
            {
                var rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Models.DrinkDetailList>(rawResponse);
                return serialize.DrinksDetail;
            }

            return Enumerable.Empty<DrinkDetail>();
        }
    }
}