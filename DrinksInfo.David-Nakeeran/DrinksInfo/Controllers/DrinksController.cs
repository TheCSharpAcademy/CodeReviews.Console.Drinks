using DrinksInfo.Utilities;
using Spectre.Console;

namespace DrinksInfo.Controllers;

class DrinksControllers
{
    private readonly Validation _validation;
    public DrinksControllers(Validation validation)
    {
        _validation = validation;
    }
    internal string? GetCategory()
    {
        var input = AnsiConsole.Ask<string>("Please enter the category of drinks you'd like to see");
        var inputValid = _validation.ValidateString("Please try again, enter the category of drinks you'd like to see", input);
        return inputValid;
    }

    internal string? GetDrinkDetail()
    {
        var input = AnsiConsole.Ask<string>("Please enter the drink id you'd like to view details of or enter 0 to return to all drink categories");
        var inputValid = _validation.ValidateDrinkId("Please try again, enter the drink id you'd like to view details of", input);
        return inputValid;
    }
}