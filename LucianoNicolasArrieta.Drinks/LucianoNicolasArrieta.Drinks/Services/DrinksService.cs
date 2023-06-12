using LucianoNicolasArrieta.Drinks.Models;
using Newtonsoft.Json;
using RestSharp;

namespace LucianoNicolasArrieta.Drinks.Services
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
    }
}
