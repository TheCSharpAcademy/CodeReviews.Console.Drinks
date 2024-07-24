using System.Web;
using DrinksInfo.Contracts.V1;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo.Controllers.V1;

/// <summary>
/// A controller for all drink related API calls.
/// </summary>
public class DrinksController
{
    #region Methods - Public

    public static IReadOnlyList<Category> GetCategories()
    {
        IReadOnlyList<Category> output = [];

        using var client = new RestClient();

        var request = new RestRequest(ApiRoutes.GetCategories);
        var reponse = client.ExecuteAsync(request);

        if (reponse.Result.StatusCode is System.Net.HttpStatusCode.OK)
        {
            output = JsonConvert.DeserializeObject<Categories>(reponse.Result.Content!)!.Values!;
        }

        return output;
    }

    public static IReadOnlyList<Drink> GetDrinksByCategory(string category)
    {
        IReadOnlyList<Drink> output = [];

        using var client = new RestClient();

        var request = new RestRequest(ApiRoutes.GetDrinksByCategory.Replace("{category}", HttpUtility.UrlEncode(category)));
        var reponse = client.ExecuteAsync(request);

        if (reponse.Result.StatusCode is System.Net.HttpStatusCode.OK)
        {
            output = JsonConvert.DeserializeObject<Drinks>(reponse.Result.Content!)!.Values!;
        }

        return output;
    }

    public static Drink? GetDrink(string drinkId)
    {
        var request = new RestRequest(ApiRoutes.GetDrink.Replace("{drinkId}", HttpUtility.UrlEncode(drinkId)));

        return GetDrink(request);
    }

    public static Drink? GetRandomDrink()
    {
        var request = new RestRequest(ApiRoutes.GetRandomDrink);

        return GetDrink(request);
    }

    #endregion
    #region Methods - Private

    private static Drink? GetDrink(RestRequest request)
    {
        List<Drink> output = [];

        using var client = new RestClient();

        var reponse = client.ExecuteAsync(request);

        if (reponse.Result.StatusCode is System.Net.HttpStatusCode.OK)
        {
            output = JsonConvert.DeserializeObject<Drinks>(reponse.Result.Content!)!.Values!;
        }

        return output.FirstOrDefault();
    }

    #endregion
}
