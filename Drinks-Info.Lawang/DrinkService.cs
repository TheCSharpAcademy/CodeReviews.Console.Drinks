using System.Net;
using System.Reflection;
using System.Web;
using drinks_info.Models;
using Drinks_Info.Lawang.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Drinks_Info.Lawang;

public class DrinkService
{

    public async Task<List<Category>> GetCategories()
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");

        try
        {
            var response = await client.GetAsync(request);
            var rawResponse = response.Content;
            if (rawResponse != null)
            {
                var categories = JsonConvert.DeserializeObject<Categories>(rawResponse);
                if (categories != null)
                {

                    Visual.ShowTitle("Drinks Info");
                    Visual.ShowCategoryTable(categories, "Categories Menu");
                    return categories.CategoriesList;
                }
            }

        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new Categories().CategoriesList;
    }

    public List<Drink> GetDrinksByCategory(string category)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");

        try
        {
            var response = client.GetAsync(request);
            if (response.Result.StatusCode == HttpStatusCode.OK)
            {
                var rawResponse = response.Result.Content;
                if (rawResponse != null)
                {
                    var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);
                    if (serialize != null)
                    {
                        Console.Clear();
                        Visual.ShowTitle("Drinks Info");
                        Visual.ShowDrinksTable(serialize, "Drinks Menu");
                        return serialize.DrinksList;
                    }
                }
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new List<Drink>();
    }

    public void GetDrink(string drink)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"lookup.php?i={drink}");

        try
        {
            var response = client.Get(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {

                var rawResponse = response.Content;
                if (rawResponse != null)
                {
                    var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);
                    List<DrinkDetail> returnedList = serialize?.DrinkDetailList ?? new();

                    DrinkDetail drinkDetail = returnedList[0];

                    List<Detail> prepList = new();

                    string formattedName = "";

                    foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
                    {
                        if (prop.Name.Contains("str"))
                        {
                            formattedName = prop.Name.Substring(3);
                        }

                        if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                        {
                            prepList.Add(new Detail
                                {
                                    Key = formattedName,
                                    Value = prop.GetValue(drinkDetail)
                                }
                            );
                        }
                    }

                    Visual.ShowDetailTable(prepList);
                    Console.ReadLine();
                }
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
