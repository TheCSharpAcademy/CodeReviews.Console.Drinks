using Dtos;
using System.Text.Json;
using Spectre.Console;

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
            categoryName = SantizeCategoryName(category.strCategory);
            await using Stream stream = await _httpClient.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={categoryName}");
            return await JsonSerializer.DeserializeAsync<DrinkList>(stream);
        }
        catch (Exception ex)
        {
           throw new Exception("Invalid operation: No data found");
        }
    }

    public string SantizeCategoryName(string categoryName)
    {
        if (categoryName.Contains("/"))
        {
            return categoryName.Split("/").First();
        }
        else if(categoryName.Contains(" "))
        {
            return categoryName.Replace(" ", "_");
        }
        else
        {
            return categoryName;
        }
    }
}
