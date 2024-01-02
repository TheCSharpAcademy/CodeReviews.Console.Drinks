using System.Reflection;
using System.Web;
using drinks_info.Models;
using Newtonsoft.Json;
using RestSharp;

namespace drinks_info
{
    internal class DrinksService
    {
        internal static List<Category> GetCategoriesList()
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                List<Category> returnedList = serialize.CategoriesList;
                
                return returnedList;
            }
            else
            {
                
                return new List<Category>();
            }
        }
        internal static List<Ingredient> GetIngredientsList()
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?i=list");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Ingredients>(rawResponse);


                List<Ingredient> returnedList = serialize.IngredientsList;
                List<Ingredient> sortedList = returnedList.OrderBy(Ingredient => Ingredient.strIngredient1).ToList();


                return sortedList;
            }
            else
            {

                return new List<Ingredient>();
            }
        }

        internal static async Task<List<Category>> GetCategoriesListAsync()
        {
            using (var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/"))
            {
                var request = new RestRequest("list.php?c=list");

                try
                {
                    var response = await client.ExecuteAsync(request);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string rawResponse = response.Content;
                        var deserialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                        List<Category> returnedList = deserialize.CategoriesList;
                        return returnedList;
                    }
                    else
                    {
                        // Handle non-OK status codes if needed
                        return new List<Category>();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions, log, etc.
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return new List<Category>();
                }
            }
        }

        internal static DrinkDetail GetDrink(string drink)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={drink}");
            var response = client.ExecuteAsync(request);
            DrinkDetail drinkDetail = new DrinkDetail();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK) 
            {
                string rawResponse = response.Result.Content;

                var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

                List<DrinkDetail> returnedList = serialize.DrinkDetailList;

                drinkDetail = returnedList[0];


                List<object> prepList = new();

                string formattedName = "";

                foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
                {
                    if (prop.Name.Contains("str"))
                    {
                        formattedName = prop.Name.Substring(3);
                    }
                    else
                    {
                        formattedName = prop.Name;
                    }

                    if(!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                    {
                        prepList.Add(new
                        {
                            Key = formattedName,
                            Value = prop.GetValue(drinkDetail)
                        });
                    }
                }
            }
            return drinkDetail;
        }
        
        internal static void GetDrinkRandom()
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"random.php");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;

                var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

                List<DrinkDetail> returnedList = serialize.DrinkDetailList;

                DrinkDetail drinkDetail = returnedList[0];

                Menu.RecepeMenu(drinkDetail);
            }
        }

        internal static List<Drink> GetDrinkListByCategory(string category)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);
            

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                List<Drink> returnedList = serialize.DrinksList;

                return returnedList;
            }
            else
            {
                return new List<Drink>();
            }
        }

        internal static List<Drink> GetDrinkListByIngredient(Ingredient ingredient)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?i={HttpUtility.UrlEncode(ingredient.strIngredient1)}");
            var response = client.ExecuteAsync(request);


            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                List<Drink> returnedList = serialize.DrinksList;

                return returnedList;
            }
            else
            {
                return new List<Drink>();
            }
        }
    }
}
