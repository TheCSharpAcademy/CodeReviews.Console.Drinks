using MiroiuDev.DrinksInfo.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Runtime.Serialization;
using System.Web;

namespace MiroiuDev.DrinksInfo;

internal class DrinksService
{
    private readonly RestClient _client;

    internal DrinksService()
    {
        _client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
    }
    internal async Task<List<Category>> GetCategoriesAsync()
    {
        var request = new RestRequest("list.php?c=list");

        var response = await _client.ExecuteAsync(request);

        if (response.IsSuccessStatusCode)
        {
            string rawResponse = response.Content ?? throw new InvalidDataException("Data is null");

            var serialized = JsonConvert.DeserializeObject<Categories>(rawResponse) ?? throw new SerializationException("Invalid serialization.");

            List<Category> categories = serialized.CategoriesList;

            return categories;
        }

        return new List<Category>();
    }

    internal async Task<List<Detail>> GetDrinkAsync(string id)
    {
        var request = new RestRequest($"lookup.php?i={id}");

        var response = await _client.ExecuteAsync(request);

        if (response.IsSuccessStatusCode)
        {
            string rawResponse = response.Content ?? throw new InvalidDataException("Data is null");

            var serialized = JsonConvert.DeserializeObject<DrinkDetails>(rawResponse) ?? throw new SerializationException("Invalid serialization.");

            Drink drinkDetails = serialized.DrinkDetailsList.FirstOrDefault() ?? throw new InvalidDataException("No drink found");

            Type type = drinkDetails.GetType();

            List<Detail> details = new();

            foreach (var property in type.GetProperties())
            {
                details.Add(new Detail
                {
                    Name = property.Name,
                    Value = property.GetValue(drinkDetails)?.ToString() ?? "",
                });
            }

            return details;
        }

        return new List<Detail>();
    }

    internal async Task<List<Drink>> GetDrinksByCategoryAsync(string category)
    {
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");

        var response = await _client.ExecuteAsync(request);

        if (response.IsSuccessStatusCode)
        {
            string rawResponse = response.Content ?? throw new InvalidDataException("Data is null");

            var serialized = JsonConvert.DeserializeObject<Drinks>(rawResponse) ?? throw new SerializationException("Invalid serialization.");

            List<Drink> drinks = serialized.DrinksList;

            return drinks;
        }

        return new List<Drink>();
    }
}
