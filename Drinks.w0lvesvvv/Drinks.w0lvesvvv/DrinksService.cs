using Drinks.w0lvesvvv.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Drinks.w0lvesvvv
{
    public static class DrinksService
    {
        private static readonly RestClient Client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");

        public static async Task<CategoryResponse?> DisplayMenu()
        {
            var response = await Client.ExecuteAsync(new RestRequest("list.php?c=list"));

            if (response.IsSuccessStatusCode)
            {
                var drinkCategoryResponse = JsonConvert.DeserializeObject<CategoryResponse>(response.Content ?? string.Empty);

                return drinkCategoryResponse;
            }

            return null;
        }

        public static async Task<CategoryDrinkResponse?> GetCategoryDrinks(string category)
        {
            var response = await Client.ExecuteAsync(new RestRequest($"filter.php?c={category}"));

            if (response.IsSuccessStatusCode)
            {
                var categoryDrinksResponse = JsonConvert.DeserializeObject<CategoryDrinkResponse>(response.Content ?? string.Empty);

                return categoryDrinksResponse;
            }

            return null;
        }

        public static async Task<List<Drink>?> GetDrinkInfo(string id)
        {
            var response = await Client.ExecuteAsync(new RestRequest($"lookup.php?i={id}"));

            if (response.IsSuccessStatusCode)
            {
                var drinkResponse = JsonConvert.DeserializeObject<DrinkResponse>(response.Content ?? string.Empty);

                return drinkResponse == null ? null : drinkResponse.Drink;
            }

            return null;
        }
    }
}
