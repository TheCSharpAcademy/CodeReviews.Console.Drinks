using Newtonsoft.Json;
using RestSharp;
using System.Configuration;

namespace csm_stough.Drinks.Services
{
    public class DrinkService
    {
        private static string ApiBaseUrl;
        private static string ApiKey;
        private static string ListCategories;
        private static string FilterByCategory;
        private static string SearchByName;

        public static void Init()
        {
            ApiBaseUrl = ConfigurationManager.AppSettings.Get("APIBaseURL");
            ApiKey = ConfigurationManager.AppSettings.Get("APIKey");
            ListCategories = ConfigurationManager.AppSettings.Get("ListCategories");
            FilterByCategory = ConfigurationManager.AppSettings.Get("FilterByCategory");
            SearchByName = ConfigurationManager.AppSettings.Get("SearchByName");
        }

        private static Task<RestResponse> ExecuteRequest(string requestStr)
        {
            RestClient client = new RestClient(ApiBaseUrl + ApiKey);
            RestRequest request = new RestRequest(requestStr);
            return client.ExecuteAsync(request);
        }

        public static List<DrinkCategory> GetDrinkCategories()
        {
            Task<RestResponse> response = ExecuteRequest(ListCategories);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DrinkCategories? serialize = JsonConvert.DeserializeObject<DrinkCategories>(response.Result.Content);

                return serialize.Categories;
            }
            return null;
        }

        public static List<Drink> GetDrinksByCategory(string category)
        {
            Task<RestResponse> response = ExecuteRequest(FilterByCategory + category);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DrinkList? serialize = JsonConvert.DeserializeObject<DrinkList>(response.Result.Content);

                return serialize.Drinks;
            }
            return null;
        }

        public static List<Drink> SearchDrinks(string search, string category)
        {
            Task<RestResponse> response = ExecuteRequest(SearchByName + search);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DrinkList serialize = JsonConvert.DeserializeObject<DrinkList>(response.Result.Content) ?? new DrinkList(new List<Drink>());

                if (serialize.Drinks != null)
                {
                    return serialize.Drinks.FindAll(drink => drink.strCategory.Equals(category));
                }

                return serialize.Drinks;
            }
            return null;
        }
    }
}
