using ConsoleTableExt;
using Drinks.w0lvesvvv;
using Drinks.w0lvesvvv.Models;


do
{
    #region Display Categories 
    Console.ForegroundColor = ConsoleColor.Green;
    CategoryResponse? CategoryResponse = await DrinksService.DisplayMenu();

    if (CategoryResponse == null || CategoryResponse.ListCategories == null)
    {
        ShowError("Not drinks found now. Trying again in 5 seconds...");
        await Task.Delay(TimeSpan.FromSeconds(5));
        continue;
    }

    List<Category> listCategories = CategoryResponse.ListCategories;

    TableBuilder.BuildTable(listCategories, ConsoleTableBuilderFormat.MarkDown);
    #endregion

    #region Display Drinks
    string category = UserInput.RequestString("Introduce category name: ");

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    CategoryDrinkResponse? categoryDrinksResponse = await DrinksService.GetCategoryDrinks(category);

    if (categoryDrinksResponse == null || categoryDrinksResponse.ListDrinks == null)
    {
        ShowError("Not drinks founded for that category.");
        continue;
    }

    TableBuilder.BuildTable(categoryDrinksResponse.ListDrinks);
    #endregion

    #region Display Drink Info
    string id = UserInput.RequestString("Introduce drink id: ");

    List<Drink>? listDrinks = await DrinksService.GetDrinkInfo(id);

    if (listDrinks == null)
    {
        ShowError("Not drinks founded for that category.");
        continue;
    }

    DisplayDrinkInfo(listDrinks.First());
    #endregion
} while (true);



#region Methods
static void DisplayDrinkInfo(Drink drink)
{
    Console.WriteLine();
    DisplayProperty("Drink", drink.strDrink);
    DisplayProperty("DrinkAlternate", drink.strDrinkAlternate);
    DisplayProperty("Tags", drink.strTags);
    DisplayProperty("Video", drink.strVideo);
    DisplayProperty("Category", drink.strCategory);
    DisplayProperty("IBA", drink.strIBA);
    DisplayProperty("Alcoholic", drink.strAlcoholic);
    DisplayProperty("Glass", drink.strGlass);
    DisplayProperty("Instructions", drink.strInstructions);
    DisplayProperty("InstructionsES", drink.strInstructionsES);
    DisplayProperty("InstructionsDE", drink.strInstructionsDE);
    DisplayProperty("InstructionsFR", drink.strInstructionsFR);
    DisplayProperty("InstructionsIT", drink.strInstructionsIT);
    DisplayProperty("InstructionsZH_HANS", drink.strInstructionsZH_HANS);
    DisplayProperty("InstructionsZH_HANT", drink.strInstructionsZH_HANT);
    DisplayProperty("Drink thumb", drink.strDrinkThumb);
    DisplayIngredients(drink.getIngredients());
    DisplayProperty("ImageSource", drink.strImageSource);
    DisplayProperty("ImageAttribution", drink.strImageAttribution);
    DisplayProperty("CreativeCommonsConfirmed", drink.strCreativeCommonsConfirmed);
    DisplayProperty("Date modified", drink.dateModified);

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Enter key to continue...");
    Console.ForegroundColor = ConsoleColor.White;
    Console.ReadLine();
    Console.Clear();
}

static void DisplayProperty(string propertyName, object? property)
{
    if (property == null) { return; }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(propertyName);
    Console.ForegroundColor = ConsoleColor.White; Console.WriteLine();
    Console.WriteLine(property);
}

static void DisplayIngredients(Dictionary<string, string> ingredients)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Ingredients");
    Console.ForegroundColor = ConsoleColor.White; Console.WriteLine();
    foreach (var item in ingredients)
    {
        Console.Write(item.Key);
        Console.WriteLine(!string.IsNullOrWhiteSpace(item.Value) ? $" ( {item.Value})" : string.Empty);
    }
}

static void ShowError(string message)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.WriteLine();
}
#endregion