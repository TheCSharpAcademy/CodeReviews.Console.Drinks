using DrinksInfo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo
{
    internal class GenerateDrinkByID
    {
        internal static void GenerateDrinks(DrinkList drinkList)
        {
            
            bool isAppRunning = true;
            while (isAppRunning)
            {
                Console.WriteLine("Enter an ID to see details of drink, or type 0 to return to categories\n");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "0")
                {
                    Console.Clear();
                    GetCategories.GetCategoriesInObjects();
                    break;
                }
                else
                {
                    if (Validation.IsValidId(userInput, drinkList))
                    {
                        using (var client = new HttpClient())
                        {
                            var endpoint = new Uri($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={userInput}");
                            var result = client.GetAsync(endpoint).Result;
                            var json = result.Content.ReadAsStringAsync().Result;

                            var deserializedGet = JsonConvert.DeserializeObject<DrinkList>(json);

                            foreach (var item in deserializedGet.drinks)
                            {
                                Console.WriteLine($"Name: {item.strDrink}\nId: {item.idDrink}\nAlcoholic?: {item.strAlcoholic}\nInstructions: {item.strInstructions}\n");

                                Console.WriteLine("Ingredients:\n");
                                foreach (var ingredient in item.Ingredients)
                                {
                                    Console.WriteLine($" - {ingredient}");
                                }
                                Console.WriteLine("---------------------");
                            }
                            GenerateDrinkByID.GenerateDrinks(deserializedGet);
                        } 
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Enter a valid ID.");
                    }
                }
            }
        }
    }
}