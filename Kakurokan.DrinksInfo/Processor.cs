using Kakurokan.DrinksInfo.Models;
using Spectre.Console;
using System;
using System.Text.Json.Serialization;

namespace Kakurokan.DrinksInfo
{
    public class Processor
    {

        public static async Task<List<string>> GetAllCategories()
        {
            using HttpResponseMessage response = await Helper.Client.GetAsync("list.php?c=list");
            
            if (response.IsSuccessStatusCode)
            {
                RootobjectCategories rootObject = await response.Content.ReadAsAsync<RootobjectCategories>();
                List<string> categories = new();

                for (int i = 0; i < rootObject.drinks.Length; i++)
                {
                    categories.Add(rootObject.drinks[i].strCategory);
                }

                return categories;

            }
            else throw new Exception(response.ReasonPhrase);
        }

        public static async Task<List<string>> GetAllDrinksByCategory(string category)
        {
            using HttpResponseMessage response = await Helper.Client.GetAsync("filter.php?c=" + category.Replace(" ", "_"));

            if (response.IsSuccessStatusCode)
            {
                RootobjectFilterByCategory rootObject = await response.Content.ReadAsAsync<RootobjectFilterByCategory>();
                List<string> categories = new();

                for (int i = 0; i < rootObject.drinks.Length; i++)
                {
                    categories.Add(rootObject.drinks[i].strDrink);
                }

                return categories;

            }
            else throw new Exception(response.ReasonPhrase);
        }

        public static async Task<Drink> GetDrink(string drink)
        {
            using HttpResponseMessage response = await Helper.Client.GetAsync("search.php?s=" + drink.Replace(" ", "_"));

            if (response.IsSuccessStatusCode)
            {
                RootobjectDrink rootObject = await response.Content.ReadAsAsync<RootobjectDrink>();
                return rootObject.drinks[0];

            }
            else throw new Exception(response.ReasonPhrase);
        }
    }
}
