using RestSharp;
using Newtonsoft.Json;
using System.Web;
using System.Reflection;

namespace Drinks.JsPeanut
{
    class DrinksService
    {
        public static List<Category> GetCategoriesList()
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            List<Category> categories = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var rawResponse = response.Result.Content;

                var deserializedResponse = JsonConvert.DeserializeObject<Categories>(rawResponse);

                categories = deserializedResponse.CategoriesList;
                TableVisualizationEngine.ShowTable(categories, "CategoriesMenu");

                return categories;
            }

            return categories;
        }

        public static List<Drink> GetDrinksByCategory(string category)
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);

            List<Drink> drinks = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var rawResponse = response.Result.Content;

                var deserializedResponse = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                drinks = deserializedResponse.DrinkList;

                TableVisualizationEngine.ShowTable(drinks, "Drinks");

                return drinks;
            }

            return drinks;
        }

        public static void GetDrink(string drink)
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={drink}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var rawResponse = response.Result.Content;

                var deserializedResponse = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

                List<DrinkDetail> returnedList = deserializedResponse.DrinkDetailList;

                DrinkDetail drinkDetail = returnedList[0];

                List<object> prepList = new();

                string formattedPropName = "";

                foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
                {
                    if (prop.Name.Contains("str"))
                    {
                        formattedPropName = prop.Name.Substring(3);
                    }

                    if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                    {
                        prepList.Add(new
                        {
                            Key = formattedPropName,
                            Value = prop.GetValue(drinkDetail)
                        });
                    }
                }

                TableVisualizationEngine.ShowTable(prepList, drinkDetail.StrDrink);
            }
        }
    }
}
