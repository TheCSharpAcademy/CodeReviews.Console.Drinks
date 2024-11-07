using Dtos;
using System.Text.Json;
using Spectre.Console;
using System.Web;
using System.Text.Json.Serialization;
using System.Dynamic;

namespace Services;

public class ManageDrinks
{
    private readonly HttpClient _httpClient;

    public ManageDrinks(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CategoryList> ProcessCategories(){
        try
        {
            await using Stream stream = await _httpClient.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
            return await JsonSerializer.DeserializeAsync<CategoryList>(stream) ?? new(null);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            throw;
        }
    }

    public async Task<DrinkList> ProcessDrinksByCategory(string categoryName){
        try
        {
            var categories = await ProcessCategories();
            var categoryNameList = categories.drinks;
            var category = categoryNameList.Find(Category => Category.strCategory.ToLower() == categoryName.ToLower());
            if (category == null)
            {
                AnsiConsole.MarkupLine("[red]The category doesn't exist[/]");
                return null;
            }
            await using Stream stream = await _httpClient.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={HttpUtility.UrlDecode(categoryName)}");
            return await JsonSerializer.DeserializeAsync<DrinkList>(stream);
        }
        catch (Exception ex)
        {
           throw new Exception("Invalid operation: No data found");
        }
    }

    public async Task<dynamic> ProcessDrinksDetailsByDrinkId(string drinkId){
        try
        {
            await using Stream stream = await _httpClient.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={drinkId}");
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            var response =  await JsonSerializer.DeserializeAsync<DrinkDetailsResponse>(stream, options: options);
            dynamic nonNullDrinkDetails = new ExpandoObject();
            var properties = typeof(DrinkDetails).GetProperties();

            foreach (var property in properties)
            {
                foreach (var drink in response.Drinks)
                {
                    var value = property.GetValue(drink);
                    if (value != null)
                    {
                        ((IDictionary<string, object>)nonNullDrinkDetails)[property.Name] = value;
                    }
                }
            }
            return (IDictionary<string, object>)nonNullDrinkDetails;
        }
        catch
        {
            throw new Exception("Invalid operation: No data found");
        }
    }
}
