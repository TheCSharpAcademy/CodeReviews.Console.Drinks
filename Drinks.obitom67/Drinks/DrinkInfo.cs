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

            
            foreach(var prop in root.Drinks[0].GetType().GetProperties())
            {
                
                var printValue = prop.GetValue(root.Drinks[0], null);
                string cleanValue;
                
                if (printValue != null)
                {
                    if (prop.Name.ToLower().Contains("str"))
                    {
                        cleanValue =prop.Name.Remove(0, 3);
                        if (cleanValue.ToLower().Contains("instructions") && cleanValue.Length != 12)
                        {
                            continue;
                        }                    
                    }
                    else if (prop.Name.ToLower().Contains("id"))
                    {
                        cleanValue = "ID Drink";
                       
                    }
                    else
                    {
                        cleanValue = prop.Name;
                    }
                    AnsiConsole.WriteLine($"{cleanValue} : {prop.GetValue(root.Drinks[0], null)}");
                }                
            }

            AnsiConsole.Confirm("Continue with learning about drinks?");
            AnsiConsole.Clear();
        }
    }
}
