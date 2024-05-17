using Newtonsoft.Json;
using System.Text.Json.Nodes;
using static Drinks.DrinksType;

namespace Drinks
{
    internal class DrinkInfo
    {
        public async void GetDrinkInfo(string userDrink)
        {
            var options = new RestClientOptions("https://www.thecocktaildb.com/api/json/v1/1");
            var client = new RestClient(options);
            var request = new RestRequest($"/search.php?s={userDrink}");
            var drinksJson = client.Get<JsonObject>(request);

            DrinksType.Root root = JsonConvert.DeserializeObject<Root>(drinksJson.ToJsonString());

            var drinkType = root.Drinks.GetType();
            foreach(var prop in root.Drinks[0].GetType().GetProperties())
            {
                
                var printValue = prop.GetValue(root.Drinks[0], null);
                if (printValue != null)
                {
                    AnsiConsole.WriteLine($"{prop.Name}:{prop.GetValue(root.Drinks[0], null)}");
                }
                
            }


        }
    }
}
