using static drinks_info.GlobalVariables;
using drinks_info.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Reflection.PortableExecutable;
using System.Collections.Generic;

namespace drinks_info
{
    internal class Helpers
    {
        internal static List<Tuple<string, string>> getIngrediantlist(DrinkDetail drinkDetail)
        {
            List<Tuple<string, string>> ingredientList = new List<Tuple<string, string>>();

         
                for (int i = 15; i >= 1; i--)
                {
                    string variableIngredientName = $"strIngredient{i}";
                    string variableMeasureName = $"strMeasure{i}";

                    var measurementObject = typeof(DrinkDetail).GetProperty(variableMeasureName)?.GetValue(drinkDetail);
                    var ingredientObject = typeof(DrinkDetail).GetProperty(variableIngredientName)?.GetValue(drinkDetail);

                    string strMeasurement = measurementObject?.ToString().Trim();
                    string strIngredient = ingredientObject?.ToString().Trim();

                    bool inInventory = Inventory.InInventory(strIngredient);
                    if (inInventory)
                    {
                    strIngredient = "*"+strIngredient+"*";
                    }

                    // Use String.IsNullOrWhiteSpace to check for empty or white spaces
                    if (!string.IsNullOrWhiteSpace(strIngredient) && !string.IsNullOrWhiteSpace(strMeasurement))
                    {
                        ingredientList.Add(new Tuple<string, string>(strIngredient, strMeasurement));
                    }
                }
            return ingredientList;
        }

        internal static Dictionary<Drink, int> MultiSearch(List<string> multipleIngrediants)
        {
            int numberOfIngrediants = multipleIngrediants.Count;
            List<Ingredient> ingredients = new List<Ingredient>();

            List<Drink> drinks = new List<Drink>();

            foreach (string multiIngrediant in multipleIngrediants)
            {
                ingredients = multipleIngrediants.Select(multiSelected => new Ingredient { strIngredient1 = multiSelected }).ToList();
            }

            foreach (Ingredient ingredient in ingredients)
            {
                List<Drink> retreivedDrinks = DrinksService.GetDrinkListByIngredient(ingredient);
                drinks.AddRange(retreivedDrinks);
            }


            Dictionary<Drink, int> drinkInfoDict = new Dictionary<Drink, int>();

            foreach (Drink drink in drinks)
            {
                if (drinkInfoDict.ContainsKey(drink))
                {
                    drinkInfoDict[drink] = drinkInfoDict[drink] +1;
                }
                else
                {
                    drinkInfoDict[drink] = 1;
                }
            }

            return drinkInfoDict;
        }

        internal static void SetEnvironmentVariables()
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetStdHandle(int nStdHandle);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern void SetConsoleOutputCP(uint wCodePageID);

            // Set the console font to Lucida Console (or any font that supports Unicode)
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Set the console output code page to UTF-8
            SetConsoleOutputCP(65001);

        }

        internal static List<string> stringBreaker(string input, int maxLineLength)
        {
            List<string> lines = new List<string>();

            input = input.Trim();

            string[] crbreaks = input.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            foreach (string lineBreak in crbreaks)
            {
                string workingCopyOfLineBreak = lineBreak.Trim();
                while (workingCopyOfLineBreak.Length > maxLineLength)
                {
                    int breakIndex = workingCopyOfLineBreak.LastIndexOf(' ', maxLineLength);
                    if (breakIndex == -1)
                    {
                        breakIndex = maxLineLength;
                    }

                    lines.Add(workingCopyOfLineBreak.Substring(0, breakIndex).Trim());
                    workingCopyOfLineBreak = workingCopyOfLineBreak.Substring(breakIndex).Trim();
                }

                if (!string.IsNullOrWhiteSpace(workingCopyOfLineBreak))
                {
                    lines.Add(workingCopyOfLineBreak);
                }
            }

            return lines;
        }

        internal static string CleanString(string input) 
        {

            input = input.Replace("*", "");
            input = input.Replace(green, "");
            input = input.Replace(resetColor, "");
            input = input.Trim();

            return input;
        }

        internal static List<Drink> DictionaryToList(int matches, Dictionary<Drink, int> drinkInfoDict)
        {
            List<Drink> drinks = new List<Drink>();
            foreach (var pair in drinkInfoDict)
            {
                string remove = $" ({pair.Value}) ";
                if (pair.Key.strDrink.EndsWith(remove))
                { 
                    pair.Key.strDrink = pair.Key.strDrink.Substring(0, pair.Key.strDrink.Length - remove.Length);
                }

                pair.Key.strDrink = pair.Key.strDrink + " (" + pair.Value + ") ";
                
                if (pair.Value >= matches)
                { 
                    drinks.Add(pair.Key);
                }
            }
            return drinks;
        }

        internal static Dictionary<Drink, int> SortDictionaryByTvalue(Dictionary<Drink, int> drinkInfoDict)
        {
            Dictionary<Drink, int> sortedDictionary = drinkInfoDict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            return sortedDictionary;
        }
    }
}


