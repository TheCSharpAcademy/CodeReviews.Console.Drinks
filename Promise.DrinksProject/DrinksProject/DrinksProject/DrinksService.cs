using Newtonsoft.Json;
using System.Reflection;

namespace DrinksProject
{
    public class DrinksService
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = "https://www.thecocktaildb.com/api/json/v1/1/";
        private List<Category> _categories = new();
        private List<Drink> _drinks = new();

        public DrinksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(baseUrl);

        }
        public async Task<List<Category>> GetAllDrinksCategories()
        {
            var url = "list.php?c=list";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response =    _httpClient.Send(request);
            if (response.IsSuccessStatusCode)
            {
                var content =  await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Categories>(content);

                _categories = result.CategoriesList;

                TableVisualization.CreateTable(_categories, "Categories Menu");
                return _categories;
            }
            return _categories;

        }
        public async Task<List<Drink>> GetDrinksByCategory(string category)
        {
            var url = $"filter.php?c={category}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response =  _httpClient.Send(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Drinks>(content);

                _drinks = result.DrinksList;
                TableVisualization.CreateTable(_drinks, "Drinks Menu");
                return _drinks;
            }
            return _drinks;
        }
        public async void GetDrinkById(string drink)
        {
            var url = $"lookup.php?i={drink}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = _httpClient.Send(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<DrinkDetailObject>(content);

                List<DrinkDetail> drinks = result.DrinkDetailList;

                DrinkDetail drinkDetail = drinks[0];
                List<object> prepList = new();
                string formattedName = "";

                foreach(PropertyInfo prop in drinkDetail.GetType().GetProperties())
                {
                    if (prop.Name.Contains("str"))
                    {
                        formattedName = prop.Name.Substring(3);
                    }
                    if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                    {
                        prepList.Add(new
                        {
                            Key = formattedName,
                            Value = prop.GetValue(drinkDetail)
                        });
                    }

                }

                TableVisualization.CreateTable(prepList, "Drink Info");
            }

        }
    }
}
