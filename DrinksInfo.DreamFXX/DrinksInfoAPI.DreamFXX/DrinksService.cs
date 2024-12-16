using RestSharp;

namespace DrinksInfo.DreamFXX;

public class DrinksService
{
    public void GetCategories()
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        // Continue!
    }
    
}