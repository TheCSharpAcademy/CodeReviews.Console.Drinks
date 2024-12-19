using System.Net;
using DrinksInfo.DreamFXX.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo.DreamFXX;

public class DrinksService
{
    public void GetCategories()
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);
        if (response.Result.StatusCode == HttpStatusCode.OK)
        {
            var rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

            List<Category> returnedList = serialize.CategoriesList;

            TableVisualizationEngine.ShowTable(returnedList, "Categories Menu");
        }
    }
}