using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Views;

/// <summary>
/// A page which displays a parameterised message and title.
/// </summary>
internal class MessagePage : BasePage
{
    #region Methods

    internal static void Show(string title, Exception exception)
    {
        AnsiConsole.Clear();

        WriteHeader(title);

        AnsiConsole.WriteException(exception, ExceptionFormats.NoStackTrace);

        WriteFooter();
    }

    internal static void Show(string title, Table table)
    {
        AnsiConsole.Clear();

        WriteHeader(title);

        AnsiConsole.Write(table);

        WriteFooter();
    }

    #endregion
}
