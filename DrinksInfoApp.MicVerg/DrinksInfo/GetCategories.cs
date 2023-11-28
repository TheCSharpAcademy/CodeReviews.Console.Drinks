using DrinksInfo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo
{
    internal class GetCategories
    {
        public static void GetCategoriesInObjects() 
        {
            Console.Clear();

            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;

                var deserializedGet = JsonConvert.DeserializeObject<CategoriesList>(json);

                Console.WriteLine("Categories" + " |");
                Console.WriteLine("---------------------");
                foreach (var category in deserializedGet.drinks)
                {
                    Console.WriteLine($"{category.strCategory}" + " |");
                    Console.WriteLine("---------------------");
                }
                GetDrinksByCategory.GenerateDrinksByCategory(deserializedGet);
            }
        }
    }
}
