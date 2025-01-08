using Newtonsoft.Json;
using RestSharp;
using System.Reflection;
using System.Web;

namespace Drinks
{
    internal class Controller
    {
        internal List<Category> GetCategories()
        {
            RestClient client = new("http://www.thecocktaildb.com/api/json/v1/1/");
            RestRequest request = new("list.php?c=list");
            Task<RestResponse> response = client.ExecuteAsync(request);
            List<Category> returnedList = new();
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string? rawResponse = response.Result.Content;
                Categories? serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                returnedList = serialize.CategoriesList;

                return returnedList;
            }
            return returnedList;
        }

        internal List<Drink> GetDrinks(string category)
        {
            RestClient client = new("http://www.thecocktaildb.com/api/json/v1/1/");
            RestRequest request = new($"filter.php?c={HttpUtility.UrlEncode(category)}");
            Task<RestResponse> response = client.ExecuteAsync(request);
            List<Drink> returnedList = new();
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                Drinks? serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                returnedList = serialize.DrinksList;

                return returnedList;
            }
            return returnedList;
        }

        internal DrinkDetail GetDrinkDetail(string drink)
        {
            RestClient client = new("http://www.thecocktaildb.com/api/json/v1/1/");
            RestRequest request = new($"lookup.php?i={drink}");
            Task<RestResponse> response = client.ExecuteAsync(request);
            List<DrinkDetail> returnedList = new();
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string? rawResponse = response.Result.Content;
                DrinkDetailObject? serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);
                returnedList = serialize.DrinkDetailList;
                DrinkDetail drinkDetail = returnedList[0];
                return drinkDetail;
            }
            return returnedList[0];
        }

        internal List<DetailOutPut> FormatDrinkDetail(DrinkDetail drinkDetail)
        {
            List<DetailOutPut> formattedDrinkDetail = new();
            string formattedName = "";
            foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
            {
                if (prop.Name.Contains("str")) formattedName = prop.Name.Substring(3);
                if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString())) formattedDrinkDetail.Add(new DetailOutPut{Name = formattedName, Value = prop.GetValue(drinkDetail).ToString()});
            }
            return formattedDrinkDetail;
        }
    }
}
