using DrinksInfo.Contracts.V1;
using DrinksInfo.Controllers.V1;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Services;

/// <summary>
/// Service to interact with the DrinksController.
/// Uses Status and Spinner due to delay in API reponse times.
/// </summary>
internal static class DrinksService
{
    #region Methods

    internal static Drink? GetDrink(string drinkId)
    {
        Drink? drink = null;

        AnsiConsole.Status()
            .Spinner(Spinner.Known.Aesthetic)
            .Start("Getting selected drink. Please wait...", ctx =>
            {
                drink = DrinksController.GetDrink(drinkId);
            });

        return drink;
    }

    internal static IReadOnlyList<Drink> GetDrinksByCategory(string category)
    {
        IReadOnlyList<Drink> drinks = [];

        AnsiConsole.Status()
            .Spinner(Spinner.Known.Aesthetic)
            .Start("Getting drinks. Please wait...", ctx =>
            {
                drinks = DrinksController.GetDrinksByCategory(category);
            });

        return drinks;
    }

    internal static Drink? GetRandomDrink()
    {
        Drink? drink = null;

        AnsiConsole.Status()
            .Spinner(Spinner.Known.Aesthetic)
            .Start("Getting random drink. Please wait...", ctx =>
            {
                drink = DrinksController.GetRandomDrink();
            });

        return drink;
    }

    #endregion
}
