using Buutyful.Drinks;
using Buutyful.Drinks.Models;
using Spectre.Console;

HttpDrinksClient client = new();

Console.WriteLine("Welcome to the Drinks Explorer!");
int count = 1;
while (true)
{
    if(count % 2 == 0) Console.Clear();
    //--------------Display drinks categories menu---------------------
    #region Categories Menu

    var categories = await client.GetDrinkCategoriesAsync();
    var category = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What's your [green]favorite drink[/]?")
            .PageSize(10)
            .MoreChoicesText("[grey](scroll down menu)[/]")
            .AddChoices(categories.Select(c => c.StrCategory)));

    #endregion
    //-----------------------------------------------------------------

    //--------------Display drinks in category menu--------------------
    #region Drinks in Category Menu

    var drinks = await client.GetDrinksByCategoryAsync(category);
    var drink = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Wanna know more [green]about it[/]?")
            .PageSize(10)
            .MoreChoicesText("[grey](scroll down menu)[/]")
            .AddChoices(drinks.Select(d => d.StrDrink)));

    #endregion
    //-----------------------------------------------------------------

    //--------------Display drink details table------------------------
    #region Drink Details

    var details = await client.GetDrinkDetailsAsync(drink);
    var properties = details.GetType().GetProperties();
    var values = properties.ToDictionary(prop => prop.Name,
                                         prop => prop.GetValue(details) as string ??
                                         "no data");

    foreach (var kvp in values)
    {
        if (kvp.Value.Equals("no data")) continue;
        AnsiConsole.MarkupLine("[green]{0}[/]: [yellow]{1}[/]", kvp.Key, kvp.Value);
    }

    Console.ReadLine();

    #endregion
    //-----------------------------------------------------------------
    count++;
}