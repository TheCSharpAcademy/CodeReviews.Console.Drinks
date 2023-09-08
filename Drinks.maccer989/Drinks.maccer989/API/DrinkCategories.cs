using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Drinks.maccer989
{
    public class DrinkCategories
    {
        public List<Category> GetCategories()
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            List<Category> categories = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                categories = serialize.CategoriesList;
                TableVisualisation.ShowTable(categories, "Categories Menu");
                return categories;
            }

            return categories;
        }

    }
}
