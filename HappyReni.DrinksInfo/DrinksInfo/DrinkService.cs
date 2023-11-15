using DrinksInfo.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo
{
    public class DrinkService
    {
        public List<Category> GetCategories()
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);
            var categories = new List<Category>();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                categories = serialize.CategoriesList;
                UI.MakeTable(categories, "Categories Menu");

                return categories;
            }
            return categories;
        }
        public List<Drink> GetDrinksByCategory(string category)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={category}");
            var response = client.ExecuteAsync(request);
            var drinks = new List<Drink>();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                drinks = serialize.DrinkList;
                UI.MakeTable(drinks, "Drinks");
                return drinks;
            }
            return drinks;
        }
        public List<object> GetDrinksDetail(int id)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={id}");
            var response = client.ExecuteAsync(request);
            var propList = new List<object>();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<DrinkDetails>(rawResponse);

                List<DrinkDetail> returnedList = serialize.DetailList;
                var detail = returnedList[0];
                var trimmedName = "";

                foreach(var prop in detail.GetType().GetProperties())
                {
                    if (prop.Name.Contains("str"))
                    {
                        trimmedName = prop.Name.Substring(3);
                    }

                    if (prop.GetValue(detail) == null) continue;
                    
                    propList.Add(new
                    {
                        Key = trimmedName,
                        Value = prop.GetValue(detail)
                    });
                }
                UI.MakeTable(propList, "Drinks Info");
                return propList;
            }
            return propList;
        }
    }
}
