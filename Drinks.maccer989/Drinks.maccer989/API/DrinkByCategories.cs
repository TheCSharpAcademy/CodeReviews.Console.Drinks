using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using RestSharp;

namespace Drinks.maccer989
{
    public class DrinkByCategories
    {
        internal List<Drink> GetDrinksByCategory(string category)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");

            var response = client.ExecuteAsync(request);

            List<Drink> drinks = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;

                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                drinks = serialize.DrinksList;

                TableVisualisation.ShowTable(drinks, "Drinks Menu");

                return drinks;

            }

            return drinks;

        }
    }
}
