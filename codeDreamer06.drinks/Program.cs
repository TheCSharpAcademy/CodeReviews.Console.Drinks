using Newtonsoft.Json.Linq;

namespace Drinks;

class Program
{
    private static readonly HttpClient client = new();
    private static readonly string baseUrl = "https://www.thecocktaildb.com/api/json/v1/1/";

    static async Task Main(string[] args)
    {
        var actions = new Dictionary<int, Func<Task>>
        {
            { 1, async () =>  await ObtainCocktails("Category", "Choose a category:") },
            { 2, async () =>  await ObtainCocktails("Glass", "Choose a glass:") },
            { 3, async () => await ObtainCocktails("Ingredient1", "Choose an Ingredient:") },
            { 4, async () =>  await ObtainCocktails("Alcoholic", "Choose an option:") }
        };

        Console.WriteLine(HelperMethods.helpMessage);
        var command = Convert.ToInt32(Console.ReadLine());
        await actions[command]();
    }

    static async Task ObtainCocktails(string requestType, string message)
    {
        var drinks = await GetAllCockTails(requestType);

        Console.WriteLine(message);
        HelperMethods.DisplayDataAsTable(drinks!);

        try
        {
            var itemId = Convert.ToInt32(Console.ReadLine()) - 1;
            var itemName = drinks?[itemId]?.ToString().Replace(" ", "_");

            Console.WriteLine($"Choose a cocktail:");
            (drinks, var ids) = await GetCockTailsByFilter($"filter.php?{requestType.ToLower()[0]}={itemName!}");
            HelperMethods.DisplayDataAsTable(drinks!);

            itemId = Convert.ToInt32(Console.ReadLine()) - 1;
            var details = await GetCockTailDetails(Convert.ToInt32(ids[itemId]));
            Console.WriteLine(details);
        }

        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid number.");
        }

        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Please enter a number from the given list.");
        }
    }

    static async Task<JToken[]> GetAllCockTails(string listType)
    {
        string filterUrl = $"{baseUrl}list.php?{listType.ToLower()[0]}=list";
        string json = await client.GetStringAsync(filterUrl);

        var drinks = JObject.Parse(json)["drinks"]?
            .Select(drink => drink["str" + listType]).ToArray();

        return drinks!;
    }

    static async Task<(JToken[], JToken[])> GetCockTailsByFilter(string filter)
    {
        string json = await client.GetStringAsync(baseUrl + filter);

        var cocktails = JObject.Parse(json)["drinks"]?
            .Select(drink => drink["strDrink"]).ToArray();

        var ids = JObject.Parse(json)["drinks"]?
            .Select(drink => drink["idDrink"]).ToArray();

        return (cocktails, ids)!;
    }

    static async Task<string> GetCockTailDetails(int id)
    {
        string json = await client.GetStringAsync(baseUrl + $"lookup.php?i={id}");
        var result = JObject.Parse(json);

        var drinks = result["drinks"]?[0]!;
        var message = @$"
Name: {drinks["strDrink"]}
Instructions: {drinks["strInstructions"]}
Date modified: {drinks["dateModified"]}
Ingredients:";

        var properties = result.Descendants().OfType<JProperty>().Where(p => p.Value.Type != JTokenType.Array && p.Value.Type != JTokenType.Object);
        var ingredients = new List<string>();
        var measures = new List<string>();

        foreach (var property in properties)
        {
            string text = property.ToString();
            if (!text.Contains("null"))
            {
                if (text.Contains("strIngredient"))
                    ingredients.Add(text[19..^1]);

                else if (text.Contains("strMeasure"))
                    measures.Add(text[16..^1]);
            }
        }

        foreach (var ingredient in ingredients.Zip(measures, (i, m) => new { ingredient = i, measure = m }))
            message += $"\n{ingredient.ingredient}, {ingredient.measure}";

        return message;
    }
}