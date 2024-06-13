using DrinksInfo.HopelessCoding.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Web;

namespace DrinksInfo.HopelessCoding;

public class DrinksService
{
    public List<Category> GetCategories()
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1");
        var request = new RestRequest("/list.php?c=list");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponseData = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponseData);

            List<Category> categoryList = serialize.CategoriesList;
            return categoryList;
        }
        else
        {
            throw new Exception($"Failed to get list of categories. Status code: {response.Result.StatusCode}");
        }
    }

    public List<Drink> GetDrinks(string category)
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1");
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponseData = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponseData);

            List<Drink> drinkList = serialize.DrinksList;
            return drinkList;
        }
        else
        {
            throw new Exception($"Failed to get drinks for category '{category}'. Status code: {response.Result.StatusCode}");
        }
    }

    public void GetDrinkDetailsData(string drinkId)
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1");
        var request = new RestRequest($"/lookup.php?i={HttpUtility.UrlEncode(drinkId)}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponseData = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<DrinkDetails>(rawResponseData);

            List<DrinkDetail> drinkDetailList = serialize.DrinkDetailList;
            DrinkDetail drinkDetail = drinkDetailList[0];

            List<(string, string)> formattedDrinkDetailList = new();
            string formattedName = "";
            var counter = 1;

            foreach (var property in drinkDetail.GetType().GetProperties())
            {
                if (property.Name.StartsWith("str"))
                {
                    formattedName = property.Name.Substring(3);
                }

                if (!string.IsNullOrEmpty(property.GetValue(drinkDetail)?.ToString()))
                {
                    if (!property.Name.StartsWith("strIngredient") && !property.Name.StartsWith("strMeasure"))
                    {
                        formattedDrinkDetailList.Add((formattedName, property.GetValue(drinkDetail)?.ToString()));
                    }
                    else
                    {
                        var ingredient = (string)drinkDetail.GetType().GetProperty($"strIngredient{counter}")?.GetValue(drinkDetail);
                        var measure = (string)drinkDetail.GetType().GetProperty($"strMeasure{counter}")?.GetValue(drinkDetail);

                        if (!string.IsNullOrEmpty(ingredient) || !string.IsNullOrEmpty(measure))
                        {
                            formattedDrinkDetailList.Add(($"{counter}.Ingredient + measure", $"{measure}{ingredient}".Trim()));
                        }
                        counter++;
                    }
                }
            }
            DataVisualisationEngine.ShowDrinkDetails(formattedDrinkDetailList);
            Console.Write($"\nPress any key to return menu...");
            Console.ReadKey(true);
        }
    }
}
