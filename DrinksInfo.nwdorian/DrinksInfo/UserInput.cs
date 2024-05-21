using Spectre.Console;

namespace DrinksInfo;
public class UserInput
{
    private readonly IDrinksService _drinksService;
    public UserInput(IDrinksService drinksService)
    {
        _drinksService = drinksService;
    }
    public async Task GetCategoriesInput()
    {
        var categories = await _drinksService.GetCategories();

        string category = AnsiConsole.Prompt(
            new TextPrompt<string>("Choose category: ")
            .ValidationErrorMessage("[red]Invalid category[/]")
            .Validate(Validation.IsStringValid));

        if (!categories.Any(x => x.strCategory.ToLower() == category.ToLower()))
        {
            AnsiConsole.MarkupLine("[red]Category doesn't exist![/]");
            await GetCategoriesInput();
        }

        await GetDrinksInput(category);
    }

    public async Task GetDrinksInput(string category)
    {
        var drinks = await _drinksService.GetDrinksByCategory(category);

        string drink = AnsiConsole.Prompt(
            new TextPrompt<string>("Choose a drink (press 0 to go back to categories): ")
            .ValidationErrorMessage("[red]Invalid Id[/]")
            .Validate(Validation.IsIdValid));

        if (drink == "0")
        {
            await GetCategoriesInput();
        }

        if (!drinks.Any(x => x.idDrink == drink))
        {
            AnsiConsole.MarkupLine("[red]Drink doesn't exist![/]");
            await GetDrinksInput(category);
        }

        await _drinksService.GetDrink(drink);

        AnsiConsole.Write("Press any key to go back to categories menu... \n");
        Console.ReadKey();
        if (!Console.KeyAvailable) await GetCategoriesInput();
    }
}
