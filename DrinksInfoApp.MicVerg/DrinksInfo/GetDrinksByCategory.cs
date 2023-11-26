using DrinksInfo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo
{
    internal class GetDrinksByCategory
    {
        internal static void GenerateDrinksByCategory(CategoriesList someList)
        {
            bool isAppRunning = true;
            while (isAppRunning)
            {
                Console.WriteLine("\nEnter the category you want to see (or type <quit>):\n");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "quit")
                {
                    isAppRunning = false;
                    Console.WriteLine("\nGoodbye.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    if (Validation.IsValidCategory(userInput, someList))
                    {
                        using (var client = new HttpClient())
                        {
                            var endpoint = new Uri($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={userInput}");
                            var result = client.GetAsync(endpoint).Result;
                            var json = result.Content.ReadAsStringAsync().Result;

                            var deserializedGet = JsonConvert.DeserializeObject<DrinkList>(json);

                            foreach (var category in deserializedGet.drinks)
                            {
                                Console.WriteLine($"Name: {category.strDrink}\n Id: {category.idDrink}");
                                Console.WriteLine("---------------------");
                            }
                            GenerateDrinkByID.GenerateDrinks(deserializedGet);
                        } 
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Enter a valid category.");
                    }
                }
            }
        }
    }
}
