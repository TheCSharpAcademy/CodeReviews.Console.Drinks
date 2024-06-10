using System.Reflection;
using System.Web;
using DrinksInfo.kalsson.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo.kalsson;

/// <summary>
/// Class representing a service for managing drinks information.
/// </summary>
public class DrinksService
    {
        /// <summary>
        /// Retrieves a list of drink categories.
        /// </summary>
        /// <returns>A list of drink categories.</returns>
        public List<Category> GetCategories()
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            List<Category> categories = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                categories = serialize.CategoriesList;
                TableVisualisationEngine.ShowTable(categories, "Categories Menu");
                return categories;
            }

            return categories;
        }

        /// <summary>
        /// Retrieves a list of drinks by category.
        /// </summary>
        /// <param name="category">The category of drinks.</param>
        /// <returns>A list of drinks.</returns>
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

                TableVisualisationEngine.ShowTable(drinks, "Drinks Menu");

                return drinks;

            }

            return drinks;

        }

        /// <summary>
        /// Retrieves the details of a specific drink from thecocktaildb API.
        /// </summary>
        /// <param name="drink">The ID of the drink to retrieve.</param>
        internal void GetDrink(string drink)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={drink}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;

                var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

                List<DrinkDetail> returnedList = serialize.DrinkDetailList;

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

                TableVisualisationEngine.ShowTable(prepList, drinkDetail.strDrink);
            }
        }
    }