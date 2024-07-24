using DrinksInfo.ConsoleApp.Engines;
using DrinksInfo.ConsoleApp.Enums;
using DrinksInfo.ConsoleApp.Models;
using DrinksInfo.ConsoleApp.Services;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Views;

/// <summary>
/// The main menu page of the application.
/// </summary>
internal class MainMenuPage : BasePage
{
    #region Constants

    private const string PageTitle = "Main Menu";

    #endregion
    #region Properties

    internal static IEnumerable<UserChoice> PageChoices
    {
        get
        {
            return
            [
                new(1, "Select drink by category"),
                new(2, "Random drink"),
                new(0, "Close application")
            ];
        }
    }

    #endregion
    #region Methods - Internal

    internal static void Show()
    {
        var status = PageStatus.Opened;

        while (status != PageStatus.Closed)
        {
            AnsiConsole.Clear();

            WriteHeader(PageTitle);

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<UserChoice>()
                .Title(PromptTitle)
                .AddChoices(PageChoices)
                .UseConverter(c => c.Name!)
                );

            status = PerformOption(option);
        }
    }

    #endregion
    #region Methods - Private

    private static PageStatus PerformOption(UserChoice option)
    {
        switch (option.Id)
        {
            case 1:

                SelectDrinkByCategory();
                break;

            case 2:

                ViewRandomDrink();
                break;

            default:

                return PageStatus.Closed;
        }

        return PageStatus.Opened;
    }

    private static void SelectDrinkByCategory()
    {
        var categoryName = SelectCategoryNamePage.Show();
        if (categoryName == null)
        {
            return;
        }

        var drink = SelectDrinkPage.Show(categoryName);
        if (drink == null)
        {
            return;
        }

        var table = TableEngine.GetDrinkTable(drink);

        MessagePage.Show("Selected Drink", table);
    }

    private static void ViewRandomDrink()
    {
        var drink = DrinksService.GetRandomDrink();

        var table = TableEngine.GetDrinkTable(drink!);

        MessagePage.Show("Random Drink", table);
    }

    #endregion
}
