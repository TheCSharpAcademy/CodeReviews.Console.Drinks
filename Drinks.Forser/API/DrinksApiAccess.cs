using System.Net.Http.Json;

namespace Drinks.Forser
{
    internal class DrinksApiAccess : IDrinksApiAccess
    {
        private readonly HttpClient _apiClient;

        public DrinksApiAccess(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var response = await _apiClient.GetFromJsonAsync<CategoryResponse>("list.php?c=list");

            return response.Categories;
        }

        public async Task<DrinkDetails> GetDrinkById(int drinkId)
        {
            var response = await _apiClient.GetFromJsonAsync<DrinkDetailsResponse>($"lookup.php?i={drinkId}");

            return response.Drinks.ToList()[0];
        }

        public async Task<IEnumerable<Drink>> GetDrinksByCategory(string category)
        {
            var categoryNameUrlString = category.Replace(" ", "_");
            var response = await _apiClient.GetFromJsonAsync<DrinkResponse>($"filter.php?c={categoryNameUrlString}");

            return response.Drinks;
        }
    }
}