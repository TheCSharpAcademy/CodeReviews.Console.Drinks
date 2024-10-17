using System.Text.Json;

namespace hasona23.Drinks
{
    public static class ResponseManager
    {

        private static readonly Uri _baseAddress = new("https://www.thecocktaildb.com/api/json/v1/1/");
        public static async Task<List<Drink>> GetDrinks(DrinkCategory category)
        {
            DrinksResponse drinksResponse = new();
            using (HttpClient client = new())
            {
                client.BaseAddress = _baseAddress;
                HttpResponseMessage response = await client.GetAsync($@"filter.php?c={category.Category}");
                response.EnsureSuccessStatusCode();
                string jsonResponse = await response.Content.ReadAsStringAsync();

                drinksResponse = JsonSerializer.Deserialize<DrinksResponse>(jsonResponse) ?? new();
            }
            return drinksResponse.Drinks ?? new();
        }
        public static async Task<Drink?> GetDrinkDetails(Drink drink)
        {
            DrinksResponse drinksResponse = new DrinksResponse();
            using (HttpClient client = new())
            {
                client.BaseAddress = _baseAddress;
                HttpResponseMessage response = await client.GetAsync($@"search.php?s={drink.Name}");
                response.EnsureSuccessStatusCode();
                string jsonResponse = await response.Content.ReadAsStringAsync();

                drinksResponse = JsonSerializer.Deserialize<DrinksResponse>(jsonResponse) ?? new();
            }
            return drinksResponse.Drinks[0];
        }
        public static async Task<List<DrinkCategory>> GetCategories()
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                HttpResponseMessage response = await client.GetAsync("list.php?c=list");
                response.EnsureSuccessStatusCode();
                string jsonResponse = await response.Content.ReadAsStringAsync();
                categoryResponse = JsonSerializer.Deserialize<CategoryResponse>(jsonResponse) ?? new();
            }
            return categoryResponse.Categories ?? new();
        }

    }
}
