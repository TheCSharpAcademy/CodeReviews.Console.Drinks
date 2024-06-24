using System.Text.Json;
using DrinksApi.Categories;
using DrinksApi.Drinks;

namespace DrinksApi;

public class Api(Client httpClient)
{
    Client HttpClient = httpClient;

    public async Task<Response<List<CategoryDto>>> FetchCategories()
    {
        try
        {
            var baseListEndpoint = Util.AssertNonNull(ConfigManager.ApiRoutes()["LIST"]);

            await using Stream stream = await HttpClient.client.GetStreamAsync($"{baseListEndpoint}?c=list");

            var categoriesList = await JsonSerializer.DeserializeAsync<CategoryListDto>(stream);

            return new Response<List<CategoryDto>>(
                true,
                categoriesList?.Drinks ?? []
            );
        }
        catch (Exception ex)
        {
            return new Response<List<CategoryDto>>(
                false,
                [],
                message: ex.Message
            );
        }

    }

    public async Task<Response<List<DrinkListItemDto>>> FetchDrinksInCategory(CategoryDto category)
    {
        try
        {
            var baseListEndpoint = Util.AssertNonNull(
                ConfigManager.ApiRoutes()["FILTER"]
            );

            await using Stream stream = await HttpClient.client.GetStreamAsync(
                $"{baseListEndpoint}?c={category.StrCategory}"
            );

            var drinksList = await JsonSerializer.DeserializeAsync<DrinksFilterListDto>(stream);

            return new Response<List<DrinkListItemDto>>(
                true,
                drinksList?.Drinks ?? []
            );
        }
        catch (Exception ex)
        {
            return new Response<List<DrinkListItemDto>>(
                false,
                [],
                message: ex.Message
            );
        }

    }
}
