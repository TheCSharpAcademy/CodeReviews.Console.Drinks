using System.Globalization;
using System.Web;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo
{
    public class DrinkService
    {
        public List<Category> GetCategories(int num = 0)
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);
            List<Category> categories = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;

                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                categories = serialize.CategoriesList;

                if (num == 0) TableVisualisation.ShowCategories(categories);
            }
            return categories;
        }



        internal List<Drink> GetDrinks(string category)
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);
            List<Drink> drinks = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var rawResponse = response.Result.Content;

                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                drinks = serialize.DrinksList;

                TableVisualisation.ShowDrinks(drinks);
            }
            return drinks;
        }
        internal DrinkDetail GetDrinkDetail(string? drink)
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={drink}");
            var response = client.ExecuteAsync(request);
            DrinkDetail drinkDetail = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var rawResponse = response.Result.Content;

                var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

                List<DrinkDetail> drinkDetailsList = serialize.DrinkDetailList;

                drinkDetail = drinkDetailsList[0];

                TableVisualisation.ShowDrinkDetail(drinkDetail);

                return drinkDetail;
            }
            return drinkDetail;
        }
    }
}
