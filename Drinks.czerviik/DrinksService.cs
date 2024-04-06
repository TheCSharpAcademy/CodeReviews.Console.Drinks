using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;


namespace drinks_info
{
    public class DrinksService
    {
        private RestClient client;
        public DrinksService()
        {
            InitializeRestClient();
        }

        private void InitializeRestClient()
        {
            client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        }

        public List<Category> GetCategories()
        {
            try
            {
                var request = new RestRequest("list.php?c=list");
                var response = client.ExecuteAsync(request);

                var categories = new List<Category>();

                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = response.Result.Content;
                    var categoriesResult = JsonConvert.DeserializeObject<Categories>(jsonResponse);
                    categories = categoriesResult.CategoriesList;
                }
                return categories;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
                return new List<Category>();
            }
        }

        public List<Drink> GetDrinks(string userCategory)
        {
            try
            {
                var request = new RestRequest($"filter.php?c={userCategory}");
                var response = client.ExecuteAsync(request);

                var drinks = new List<Drink>();

                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = response.Result.Content;
                    var drinksResult = JsonConvert.DeserializeObject<Drinks>(jsonResponse);
                    drinks = drinksResult.DrinksList;
                }
                return drinks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
                return new List<Drink>();
            }
        }

        public DrinkDetail GetDrinkDetail(Drink userDrink)
        {
            var request = new RestRequest($"lookup.php?i={userDrink.Id}");
            var response = client.ExecuteAsync(request);

            var drinkDetails = new List<DrinkDetail>();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = response.Result.Content;
                var drinkDetailResult = JsonConvert.DeserializeObject<DrinkDetailResponse>(jsonResponse);
                drinkDetails = drinkDetailResult.DrinkDetails;
            }
            return drinkDetails[0];
        }
    }
}
