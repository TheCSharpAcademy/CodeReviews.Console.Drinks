using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace Drinks
{
    internal class Categories
    { 
        public List<DrinkCategory> drinks { get; set; }
        public class DrinkCategory()
        {
            public string strCategory { get; set; }
        }
        public string GetCategories()
        {
            RestClientOptions options = new RestClientOptions("https://www.thecocktaildb.com/api/json/v1/1/");
            RestClient client = new RestClient(options);
            RestRequest categoriesRequest  = new("/list.php?c=list");
            var categoryJson = client.Get<JsonObject>(categoriesRequest);

            Categories categoriesDeserial = JsonConvert.DeserializeObject<Categories>(categoryJson.ToJsonString());

            var categoryPrompt = new SelectionPrompt<string>();
            for (int i = 0; i< categoriesDeserial.drinks.Count; i++)
            {
                categoryPrompt.AddChoice(categoriesDeserial.drinks[i].strCategory);
            }
            return AnsiConsole.Prompt(categoryPrompt);
                


        }
    }
}
