using LucianoNicolasArrieta.DrinksApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;
using System.Web;

namespace LucianoNicolasArrieta.DrinksApp.Services
{
    public class DrinksService
    {
        TableVisualizationEngine tableVisualizationEngine = new TableVisualizationEngine();

        public List<Category> GetCategories()
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            List<Category> categories = new List<Category>();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                categories = serialize.CategoriesList;
                Console.WriteLine(categories.Count);

                tableVisualizationEngine.ShowTable(categories, "Categories Menu");
            }

            return categories;
        }

        public List<Drink> GetDrinksByCategory(string category)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);

            List<Drink> drinks = new List<Drink>();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                drinks = serialize.DrinksList;

                tableVisualizationEngine.ShowTable(drinks, "Drinks Menu");
            }

            return drinks;
        }

        public List<DrinkDetail> GetDrinkDetail(string drink_id)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={drink_id}");
            var response = client.ExecuteAsync(request);

            List<DrinkDetail> list = new List<DrinkDetail>();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

                list = serialize.DrinkDetailsList;

                DrinkDetail drinkDetail = list[0];

                List<object> prepList = new();

                string formattedName = "";

                foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
                {

                    if (prop.Name.Contains("Str"))
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

                tableVisualizationEngine.ShowTable(prepList, drinkDetail.StrDrink);
            }

            return list;
        }
    }
}
