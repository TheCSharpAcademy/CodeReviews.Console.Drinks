using DrinksInfo.ConsoleApp.Models;
using DrinksInfo.Contracts.V1;
using DrinksInfo.Controllers.V1;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Views;

/// <summary>
/// A page to displays a list of categories for selection.
/// </summary>
internal class SelectCategoryNamePage : BasePage
{
    #region Constants

    private const string PageTitle = "Select Category";

    #endregion
    #region Properties

    internal static IEnumerable<UserChoice> PageChoices
    {
        get
        {
            return
            [
                new(0, "Close page")
            ];
        }
    }

    #endregion
    #region Methods - Internal

    /// <summary>
    /// Gets a list of categories from the drinks controller displays for user selection.
    /// </summary>
    /// <returns>The name of the category selected, or null if user wants to close the page.</returns>
    internal static string? Show()
    {
        IReadOnlyList<Category> categories = [];
        AnsiConsole.Status()
            .Spinner(Spinner.Known.Aesthetic)
            .Start("Getting categories. Please wait...", ctx =>
            {
                categories = DrinksController.GetCategories();
            });

        WriteHeader(PageTitle);

        var option = GetOption(categories);

        return option.Id == 0 ? null : option.Name;
    }

    #endregion
    #region Methods - Private

    private static UserChoice GetOption(IReadOnlyList<Category> categories)
    {
        // Add the list to the existing PageChoices
        // Note: we do not care about the id, but it can't be 0 (close page).
        IEnumerable<UserChoice> pageChoices = [.. categories.Select(x => new UserChoice(1, x.Name!)), .. PageChoices];

        return AnsiConsole.Prompt(
                new SelectionPrompt<UserChoice>()
                .Title(PromptTitle)
                .EnableSearch()
                .AddChoices(pageChoices)
                .PageSize(15)
                .UseConverter(c => c.Name!)
                );
    }

    #endregion
}
