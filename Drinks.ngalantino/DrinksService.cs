using System.Reflection;
using System.Web;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RestSharp;

public class DrinksService
{

    public List<Category> GetCategories()
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        List<Category> returnedList = new List<Category>();

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;

            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

            returnedList = serialize.CategoriesList;

            TableVisualisationEngine.ShowTable(returnedList, "Categories Menu");

            return returnedList;
        }
        return returnedList;
    }


    public List<Drink> GetDrinksByCategory(string category)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
        var response = client.ExecuteAsync(request);

        List<Drink> returnedList = new List<Drink>();

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;

            var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

            returnedList = serialize.DrinksList;

            TableVisualisationEngine.ShowTable(returnedList, "Drinks Menu");

            return returnedList;
        }
        return returnedList;
    }

    internal void GetDrink(string drink)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"lookup.php?i={drink}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;

            DrinkDetailObject serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

            List<DrinkDetail> returnedList = serialize.DrinkDetailList;

            DrinkDetail drinkDetail = returnedList[0];

            List<object> prepList = new();

            string formattedName = "";

            foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
            {
                if (prop.Name.Contains("Str"))
                {
                    formattedName = prop.Name.Substring(3);
                }

                if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                {
                    //prop.GetValue(drinkDetail)?.ToString().Length >= 90

                    if (prop.GetValue(drinkDetail)?.ToString().Length >= 80)
                    {
                        List<string> multipleLineValue = GetNextChars(prop.GetValue(drinkDetail)?.ToString(), 80);

                        // Add first line.
                        prepList.Add(new
                        {
                            Key = formattedName,
                            Value = multipleLineValue[0].ToString()
                        });
                        // Add each additional line.
                        for (int i = 1; i < multipleLineValue.Count; i++)
                        {
                            // Remove \r and \n escape characters.
                            string line = multipleLineValue[i].ToString().Replace("\r", "").Replace("\n", "");
                            prepList.Add(new
                            {
                                Key = "",
                                Value = line
                            });
                        }
                    }
                    else
                    {
                        prepList.Add(new
                        {
                            Key = formattedName,
                            Value = prop.GetValue(drinkDetail).ToString().Replace("\r", "").Replace("\n", "")
                        });
                    }

                    prepList.Add(new
                    {
                        Key = "",
                        Value = ""
                    });

                }
            }

            TableVisualisationEngine.ShowTable(prepList, drinkDetail.StrDrink);
        }
    }

    // Function to break long string into list of substrings.
    private static List<string> GetNextChars(string str, int iterateCount)
    {
        var words = new List<string>();

        for (int i = 0; i < str.Length; i += iterateCount)
            if (str.Length - i >= iterateCount) words.Add(str.Substring(i, iterateCount));
            else words.Add(str.Substring(i, str.Length - i));

        return words;
    }

}

// Youtube 13:43