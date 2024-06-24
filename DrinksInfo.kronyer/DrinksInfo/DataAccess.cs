using DrinksInfo.Models;
using Newtonsoft.Json;
using RestSharp;
using Spectre.Console;

namespace DrinksInfo;

internal class DataAccess
{
    public static void SearchByCategories(string category)
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={category}");
        var response = client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string responseJson = response.Content;
            var serialize = JsonConvert.DeserializeObject<DrinksModel>(responseJson);

            List<Drinks> drinkslist = serialize.Drinks;

            var drinkchoice = AnsiConsole.Prompt(new SelectionPrompt<Drinks>().Title("select one drink").AddChoices(drinkslist));

            GetInfo(drinkchoice.ToString());

            Console.ReadKey();
        }
    }

    public static void GetInfo(string name)
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"search.php?s={name}");
        var response = client.Execute(request);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string responseJson = response.Content;
            var serialize = JsonConvert.DeserializeObject<DrinksModel>(responseJson);

            List<Drinks> returned = serialize.Drinks;
            Drinks selectedDrink = returned.FirstOrDefault();

            UserInterface.PrintDrink(selectedDrink);
        }
    }

    public static void RandomDrink()
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("random.php");
        var response = client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string responseJson = response.Content;
            var serialize = JsonConvert.DeserializeObject<DrinksModel>(responseJson);

            List<Drinks> returned = serialize.Drinks;
            Drinks returnedRandom = returned.FirstOrDefault();

            UserInterface.PrintDrink(returnedRandom);
        }
    }

    public static void SearchByName(string name)
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"search.php?s={name}");
        var response = client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string responseJson = response.Content;
            var serialize = JsonConvert.DeserializeObject<DrinksModel>(responseJson);

            List<Drinks> returnedList = serialize.Drinks;

            if (returnedList != null)
            {
                var drinkchoice = AnsiConsole.Prompt(new SelectionPrompt<Drinks>().Title("select one drink").AddChoices(returnedList));
                GetInfo(drinkchoice.ToString());
            }
            else
            {
                Console.WriteLine("No results found");
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }
    }
}
