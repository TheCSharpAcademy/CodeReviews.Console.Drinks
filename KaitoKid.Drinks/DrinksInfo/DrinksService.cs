using DrinksInfo.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;
using System.Web;

namespace DrinksInfo
{
    internal class DrinksService
    {
        DrinksRepo repo = new DrinksRepo();
        public List<Category> GetCategories()
        {
            repo.CreateTable();
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.GetAsync(request);

            List<Category> categories = new();
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                categories = serialize.CategoriesList;

            }

            return categories;
        }

        public List<Drink> GetDrinksByCategory(string category)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);

            List<Drink> drinks = new();
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                
                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                drinks = serialize.DrinkList;

                TableVisualisationEngine.ShowTable(drinks, "Drinks Menu");
            }

            return drinks;
        }

        public void GetDrink(string drink, string category)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={drink}");
            var response = client.ExecuteAsync(request);

            if(response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

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
                    else
                    {
                        formattedName = prop.Name; 
                    }

                    if (!String.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString())) 
                    {
                        prepList.Add(new
                        {
                            Key = formattedName,
                            Value = prop.GetValue(drinkDetail)
                        });   
                    }
                }

                TableVisualisationEngine.ShowDrinksInfo(prepList, drinkDetail.StrDrink);
                Console.Write("Add to Favorites?(Y/N): ");
                string? fav = Console.ReadLine();
                repo.Insert(category, drinkDetail.StrDrink, fav);
            }
        }

        internal void GetFavDrink()
        {
            repo.ViewFavDrinks();
        }

        internal void GetCountOfDrink()
        {
            repo.ViewCount();
        }
    }
}
