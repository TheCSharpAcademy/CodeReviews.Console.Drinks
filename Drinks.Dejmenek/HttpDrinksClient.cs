using Drinks.Dejmenek.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Drinks.Dejmenek
{
    public class HttpDrinksClient
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public HttpDrinksClient()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<DrinkCategory>> GetDrinksCategoriesAsync()
        {
            string endpoint = "list.php?c=list";
            var (status, content) = await SendRequestAsync(endpoint);

            if (status)
            {
                return JsonSerializer.Deserialize<DrinkCategoriesList>(content)?.DrinkCategories;
            }
            else
            {
                Console.WriteLine($"Error: {content}");
                return null;
            }
        }

        public async Task<List<Drink>> GetDrinksByCategoryAsync(string category)
        {
            string endpoint = $"filter.php?c={category}";
            var (status, content) = await SendRequestAsync(endpoint);

            if (status)
            {
                return JsonSerializer.Deserialize<DrinkList>(content)?.Drinks;
            }
            else
            {
                Console.WriteLine($"Error: {content}");
                return null;
            }
        }

        public async Task<Drink> GetDrinkInfoAsync(string drinkName)
        {
            string endpoint = $"search.php?s={drinkName}";
            var (status, content) = await SendRequestAsync(endpoint);

            if (status)
            {
                return JsonSerializer.Deserialize<DrinkList>(content)?.Drinks?.FirstOrDefault();
            }
            else
            {
                Console.WriteLine($"Error: {content}");
                return null;
            }
        }

        private async Task<(bool Status, string Content)> SendRequestAsync(string endpoint)
        {
            string url = $"https://www.thecocktaildb.com/api/json/v1/1/{endpoint}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return (true, await response.Content.ReadAsStringAsync());
            }
            else
            {
                return (false, $"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }
}
