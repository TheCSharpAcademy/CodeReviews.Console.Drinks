using Models;
using Newtonsoft.Json;
using Serilog;
using System.Net.Http.Headers;

namespace DataAccess
{
    public class DrinkService
    {
        private static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://thecocktaildb.com/api/json/v1/1/")
        };

        public static async Task<CategoryResponse> GetCategory()
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            try
            {
                Log.Information("Sending Get Request {https://thecocktaildb.com/api/json/v1/1/list.php?c=list}");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "1");
                HttpResponseMessage response = await client.GetAsync("list.php?c=list");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                CategoryResponse? categoryResponse = JsonConvert.DeserializeObject<CategoryResponse>(responseBody);

                if (categoryResponse?.drinks == null) throw new Exception("Deserialization failed");
                return categoryResponse;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
        public static async Task<DrinksResponse> GetDrinkList(string value)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "1");
                HttpResponseMessage response = await client.GetAsync($"filter.php?c={value}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                DrinksResponse? drinksResponse = JsonConvert.DeserializeObject<DrinksResponse>(responseBody);

                if (drinksResponse?.drinks == null) throw new Exception("Deserialization failed");
                return drinksResponse;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
        public static async Task<List<Drink>> GetDrinkDetail(string key)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "1");
                HttpResponseMessage response = await client.GetAsync($"lookup.php?i={key}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                DrinkResponse? drinkResponse = JsonConvert.DeserializeObject<DrinkResponse>(responseBody);

                if (drinkResponse?.drinks == null) throw new Exception("Deserialization failed");
                return drinkResponse.drinks;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
    }
}
