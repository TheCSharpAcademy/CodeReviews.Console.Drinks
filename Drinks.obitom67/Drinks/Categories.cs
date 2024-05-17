using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace Drinks
{
    internal class Categories
    {
        [JsonProperty("drinks")]
        public List<DrinkCategory> Drinks { get; set; }
        public class DrinkCategory()
        {
            [JsonProperty("strCategory")]
            public string StrCategory { get; set; }
        }
        public string GetCategories()
        {
            RestClientOptions options = new RestClientOptions("https://www.thecocktaildb.com/api/json/v1/1/");
            RestClient client = new RestClient(options);
            RestRequest categoriesRequest  = new("/list.php?c=list");
            var categoryJson = client.Get<JsonObject>(categoriesRequest);

            Categories categoriesDeserial = JsonConvert.DeserializeObject<Categories>(categoryJson.ToJsonString());

            var categoryPrompt = new SelectionPrompt<string>();
            for (int i = 0; i< categoriesDeserial.Drinks.Count; i++)
            {
                categoryPrompt.AddChoice(categoriesDeserial.Drinks[i].StrCategory);
            }
            return AnsiConsole.Prompt(categoryPrompt);
                


        }
    }
}
