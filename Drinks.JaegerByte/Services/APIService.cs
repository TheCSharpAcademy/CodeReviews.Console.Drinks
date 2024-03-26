using Drinks.JaegerByte.DataModels;
using Newtonsoft.Json;
using RestSharp;
using System.Web;
using System.Collections.Generic;
using System.Linq;

namespace Drinks.JaegerByte.Services
{
    public class APIService
    {
        public RestClient Client { get; set; } = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        public Categories GetCategories()
        {
            RestRequest request = new RestRequest("list.php?c=list");
            Task<RestResponse> response = Client.ExecuteAsync(request);
            string rawResponse = response.Result.Content;
            return JsonConvert.DeserializeObject<Categories>(rawResponse);
        }
        public DataModels.Drinks GetDrinks(string category)
        {
            RestRequest request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            Task<RestResponse> response = Client.ExecuteAsync(request);
            string rawResponse = response.Result.Content;
            return JsonConvert.DeserializeObject<DataModels.Drinks>(rawResponse);
        }
        public Details GetDetails(string drinkID)
        {
            RestRequest request = new RestRequest($"lookup.php?i={HttpUtility.UrlEncode(drinkID)}");
            Task<RestResponse> response = Client.ExecuteAsync(request);
            string rawResponse = response.Result.Content;
            return JsonConvert.DeserializeObject<Details>(rawResponse);
        }
    }
}
