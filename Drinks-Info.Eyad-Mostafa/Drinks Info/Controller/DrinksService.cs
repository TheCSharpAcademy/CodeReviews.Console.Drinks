using Drinks_Info.Models;
using RestSharp;
using Newtonsoft.Json;
using System.Web;
using System.Reflection;

namespace Drinks_Info.Controller;

internal static class DrinksService
{
    public static List<Category> GetCategories()
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list", Method.Get);

        var response = client.Execute(request);

        var categories = new List<Category>();

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string? rawResponse = response.Content;
            var serialize = JsonConvert.DeserializeObject<CategoryResponse>(rawResponse);

            categories = serialize.Categories;

            return categories;
        }
        else
        {
            Console.WriteLine("Error: " + response.StatusCode);
        }

        return categories;
    }

    public static List<Drink> GetDrinks(string category)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}", Method.Get);

        var response = client.Execute(request);

        var drinks = new List<Drink>();

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string? rawResponse = response.Content;
            var serialize = JsonConvert.DeserializeObject<DrinkResponse>(rawResponse);

            drinks = serialize.Drinks;

            return drinks;
        }
        else
        {
            Console.WriteLine("Error: " + response.StatusCode);
        }

        return drinks;
    }

    internal static List<DrinkDetailDto> GetDrinkDetails(string id)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"lookup.php?i={id}");
        var response = client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string? rawResponse = response.Content;

            var serialize = JsonConvert.DeserializeObject<DrinkDetailResponse>(rawResponse);

            List<DrinkDetails>? returnedList = serialize?.DrinkDetailList;

            DrinkDetails? drinkDetail = returnedList?[0];

            var prepList = new List<DrinkDetailDto>();

            string formattedName = "";

            foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
            {

                if (prop.Name.Contains("str"))
                {
                    formattedName = prop.Name.Substring(3);
                }

                if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                {
                    prepList.Add(new DrinkDetailDto
                    {
                        Name = formattedName,
                        Details = prop.GetValue(drinkDetail)
                    });
                }
            }

            return prepList;

        }
        else
        {
            Console.WriteLine("Error: " + response.StatusCode);
        }

        return new List<DrinkDetailDto>();
    }

}
