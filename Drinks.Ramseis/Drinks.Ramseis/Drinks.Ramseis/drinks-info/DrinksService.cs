using Newtonsoft.Json;
using RestSharp;
using System.Reflection;
using System.Web;
using static Drinks.Ramseis.DrinkDetails;

namespace Drinks.Ramseis
{
    internal class DrinksService
    {
        public List<Category> GetCategories()
        {
            RestClient client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            RestRequest request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            List<Category> returnedList = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content ?? "null";
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                returnedList = serialize.CategoriesList;

                TableVisualizationEngine.ShowTable(returnedList, "Categories Menu");

                return returnedList;
            }

            return returnedList;
        }

        public List<Drink> GetDrinksByCategory(string category)
        {
            RestClient client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            RestRequest request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);

            List<Drink> returnedList = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content ?? "null";
                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                returnedList = serialize.DrinksList ?? new List<Drink> { };

                TableVisualizationEngine.ShowTable(returnedList, "Drinks Menu");

                return returnedList;
            }

            return returnedList;
        }

        public void GetDrink(string drink)
        {
            RestClient client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            RestRequest request = new RestRequest($"lookup.php?i={drink}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content ?? "null";
                var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

                List<DrinkDetail> returnedList = serialize.DrinkDetailList ?? new List<DrinkDetail> { };

                DrinkDetail drinkDetail = returnedList[0];
                List<object> prepList = new();

                string formattedName = "";

                foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
                {
                    if (prop.Name.Contains("str"))
                    {
                        formattedName = prop.Name.Substring(3);
                    }
                    if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                    {
                        prepList.Add(new
                        {
                            Key = formattedName,
                            Value = prop.GetValue(drinkDetail)
                        });
                    }
                }

                TableVisualizationEngine.ShowTable(prepList, drinkDetail.strDrink);
            }
        }
    }
}
