using ClassLibrary;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo.View
{
    internal static class DrinkView
    {
        internal static void GetDrink( string drink, string category )
        {
            var jsonClient = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"search.php?s={drink}");

            var response = jsonClient.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {

                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<DrinkInformation>(rawResponse);

                List<DrinkModel> drinkDisplay = serialize.DrinkModel;

                string drinkName = drinkDisplay[0].StrDrink;
                string isAlchoholic = drinkDisplay[0].StrAlcoholic;
                string howToPrepare = drinkDisplay[0].StrInstructions;

                Console.WriteLine(HelperMethods.CenterConsoleString(drinkName));
                Console.WriteLine(HelperMethods.CenterConsoleString("-----"));
                Console.WriteLine(HelperMethods.CenterConsoleString(isAlchoholic));
                Console.WriteLine(HelperMethods.CenterConsoleString("-----"));
                Console.WriteLine(HelperMethods.CenterConsoleString(howToPrepare));
                Console.WriteLine(HelperMethods.CenterConsoleString("-----"));

                Console.WriteLine("Press ESC to return");
                ConsoleKey escape = Console.ReadKey(true).Key;

                while (escape != ConsoleKey.Escape)
                {
                    escape = Console.ReadKey().Key;
                }
                
                if (escape == ConsoleKey.Escape)
                {
                   Console.Clear();
                   DrinksListView.SelectDrink(category);
                }
            }
        }
    }
}
