using System.Net;
using Drinks.barakisbrown.Models;
using drinks_info.Models;
using Newtonsoft.Json;
using RestSharp;

public class DrinksService
{
    public IEnumerable<Category> GetCategories()
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == HttpStatusCode.OK)
        {
            var rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);
            return serialize.CategoriesList;
        }

        return Enumerable.Empty<Category>();
    }
}