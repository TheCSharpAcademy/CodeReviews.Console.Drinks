namespace TheCocktailDb;

using Drinks;
using System.Net.Http.Headers;
using System.Text.Json;

class ApiClient
{
    private readonly Uri baseUri;
    private readonly string categoriesEndpoint;
    private readonly string drinksByCategoryEndpoint;
    private readonly string drinkByIdEndpoint;


    public ApiClient(Configuration config)
    {
        if (config.TheCocktailDbBaseUri == null)
        {
            throw new InvalidOperationException("Configuration.TheCocktailDbBaseUri is null.");
        }
        baseUri = new Uri(config.TheCocktailDbBaseUri);

        if (config.TheCocktailDbCategories == null)
        {
            throw new InvalidOperationException("onfiguration.TheCocktailDbCategories is null.");
        }
        categoriesEndpoint = config.TheCocktailDbCategories;

        if (config.TheCocktailDbDrinksByCategory == null)
        {
            throw new InvalidOperationException("onfiguration.TheCocktailDbDrinksByCategory is null.");
        }
        drinksByCategoryEndpoint = config.TheCocktailDbDrinksByCategory;

        if (config.TheCocktailDbDrinkById == null)
        {
            throw new InvalidOperationException("onfiguration.TheCocktailDbDrinkById is null.");
        }
        drinkByIdEndpoint = config.TheCocktailDbDrinkById;
    }

    public async Task<IList<CategoryDto>> GetCategoriesAsync()
    {
        var categoryDtos = new List<CategoryDto>();
        using HttpClient client = PrepareHttpClient();
        var requestUri = new Uri(baseUri, categoriesEndpoint);
        using Stream stream = await client.GetStreamAsync(requestUri);
        var response = await JsonSerializer.DeserializeAsync<GetCategoriesResponse>(stream);
        if (response != null && response.Categories != null)
        {
            foreach (Category category in response.Categories)
            {
                categoryDtos.Add(new CategoryDto(category.Name));
            }
        }
        return categoryDtos;
    }

    public async Task<IList<DrinkDto>> GetDrinksByCategoryAsync(string categoryName)
    {
        var drinkDtos = new List<DrinkDto>();
        using HttpClient client = PrepareHttpClient();
        var categoryNameAsUriParam = categoryName.Replace(" ", "_");
        var endpoint = drinksByCategoryEndpoint.Replace("{CategoryName}", categoryNameAsUriParam);
        var requestUri = new Uri(baseUri, endpoint);
        using Stream stream = await client.GetStreamAsync(requestUri);
        var response = await JsonSerializer.DeserializeAsync<GetDrinksByCategoryResponse>(stream);
        if (response != null && response.Drinks != null)
        {
            foreach (Drink drink in response.Drinks)
            {
                drinkDtos.Add(new DrinkDto(int.Parse(drink.Id), drink.Name));
            }
        }
        return drinkDtos;
    }

    public async Task<DrinkDto?> GetDrinkByIdAsync(int drinkId)
    {
        using HttpClient client = PrepareHttpClient();
        var requestUri = new Uri(baseUri, drinkByIdEndpoint.Replace("{DrinkId}", drinkId.ToString()));
        using Stream stream = await client.GetStreamAsync(requestUri);
        var response = await JsonSerializer.DeserializeAsync<LookupDrinksResponse>(stream);
        if (response == null || response.Drinks == null)
        {
            return null;
        }
        return DrinkDetailToDrinkDto(response.Drinks[0]);
    }

    private HttpClient PrepareHttpClient()
    {
        HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("User-Agent", "TheCocktailDbApiClient");
        return client;
    }

    private DrinkDto DrinkDetailToDrinkDto(DrinkDetail drink)
    {
        var drinkDto = new DrinkDto(int.Parse(drink.Id), drink.Name)
        {
            Alcoholic = drink.Alcoholic,
            Category = drink.Category,
            Alternate = drink.Alternate,
            Iba = drink.Iba,
            Glass = drink.Glass,
            Instructions = drink.Instructions
        };
        drinkDto.AddIngredient(drink.Measure1, drink.Ingredient1);
        drinkDto.AddIngredient(drink.Measure2, drink.Ingredient2);
        drinkDto.AddIngredient(drink.Measure3, drink.Ingredient3);
        drinkDto.AddIngredient(drink.Measure4, drink.Ingredient4);
        drinkDto.AddIngredient(drink.Measure5, drink.Ingredient5);
        drinkDto.AddIngredient(drink.Measure6, drink.Ingredient6);
        drinkDto.AddIngredient(drink.Measure7, drink.Ingredient7);
        drinkDto.AddIngredient(drink.Measure8, drink.Ingredient8);
        drinkDto.AddIngredient(drink.Measure9, drink.Ingredient9);
        drinkDto.AddIngredient(drink.Measure10, drink.Ingredient10);
        drinkDto.AddIngredient(drink.Measure11, drink.Ingredient11);
        drinkDto.AddIngredient(drink.Measure12, drink.Ingredient12);
        drinkDto.AddIngredient(drink.Measure13, drink.Ingredient13);
        drinkDto.AddIngredient(drink.Measure14, drink.Ingredient14);
        drinkDto.AddIngredient(drink.Measure15, drink.Ingredient15);
        return drinkDto;
    }
}