using DrinksInfo.Models;
using DrinksInfo.View;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo.API
{
    public static class CategoriesApi
    {
        public static List<Category> GetDrinkCategories()
        {

            var jsonClient = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = jsonClient.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {

                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                List<Category> categories = serialize.CategoriesList;

                CreateTableEngine.ShowTable(DrinksHelper.EditList(categories), "Categories");

                return categories;
            }
            return null;
        }
    }
}
